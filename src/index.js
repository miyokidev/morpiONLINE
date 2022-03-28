const e = require('cors');
const express = require('express');
const dotenv = require('dotenv').config();
const signIn = require('./controllers/signInController.js');
const signUp = require('./controllers/signUpController.js');
const { generateRandomId, handlePlayerLeave, emitPlayerList, isPlayerInARoom } = require('./function.js');
const store = require('./store.js');

/* API APP */
const app = express();
const port = process.env.PORT;

app.use(function (req, res, next) {
    res.setHeader('Access-Control-Allow-Origin', '*')
    res.setHeader('Access-Control-Allow-Methods', 'GET, PUT, POST, DELETE')
    res.setHeader('Access-Control-Allow-Headers', 'Authorization, Content-Type')
    res.setHeader('Content-Type', 'application/json')
    next();
});
app.use(express.json());

app.get('/', (req, res) => { res.status(200).json("Welcome to the API") });
app.use('/signin', signIn);
app.use('/signup', signUp);

app.listen(port, () => {
    console.log("App listening at http://localhost:" + port)
})

/* SOCKET APP */
const socketApp = express();
const socketPort = process.env.SOCKET_PORT;

var server = require('http').createServer(socketApp);
var io = require('socket.io')(server, {
    cors: {
        origin: "*",
    }
});

let rooms = [];

io.on('connection', (socket) => {
    // On vérifie si l'utilisateur nous renseigne un token existant dans la session.
    if (store.get(socket.handshake.auth.token) != null) {
        console.log('Connected: ' + socket.id);
        var token = socket.handshake.auth.token;

        // le socket.id est différent à chaque fois qu'un utilisateur change de page ou 
        // raffraichit sa page c'est pourquoi on se sert du token pour vérifier son identité
        // et on restock son nouveau socket.id dans la session.
        var user = store.get(token);
        user.id = socket.id;
        store.set(token, user);

        //---------------------------------------------------------------
        // Gérer quand l'utilisateur change de page ou rafraichit sa page
        //----------------------------------------------------------------

        // On vérifie à l'aide de son token si il appartenait à une salle
        // roomPlayer est égal à null si il était dans aucune salle
        var roomPlayer = isPlayerInARoom(socket, rooms);

        if (roomPlayer != null) { // dans le cas où il est dans une salle
            socket.join(roomPlayer.id); // On le fait re-rejoindre sa salle socket.io
            emitPlayerList(io, roomPlayer); // On lui donne la liste des personnes dans la salle

            // Si une partie était en cours on lui renvoit les informations du match en cours
            if (roomPlayer.game.inProgress) {
                io.to(roomPlayer.id).emit('isPlayer1Turn', roomPlayer.game.isP1Turn); // A qui est le tour
                // emit grid
            }
        }

        // Déconnexion s'éxécute à chaque fois que l'utilisateur ferme sa page, change de page, raffraichit sa page
        socket.on('disconnect', () => {
            console.log('Disconnected: ' + socket.id);
        });

        //-----------------------------------------------------------------
        // ROOMS
        //-----------------------------------------------------------------
        /* Les rooms sont gérés de manière stateless tout dans le code sans base de données
        *  à l'aide d'une liste de rooms.
        */
        socket.on('createRoom', () => {
            // Si le joueur est déjà dans une room on le fait quitter
            if (roomPlayer != null) {
                rooms = handlePlayerLeave(io, socket, rooms);
            }

            // Création d'une room avec les infos par défaut
            const room = {
                id: generateRandomId(), // id unique pour chaque room permettant de les différencier
                players: [ // tableau de joueur pour y stocker les 2 joueurs participants
                    {
                        token: token, // token du joueur obtenu lors de la connexion
                        name: store.get(token).name // pseudo du joueur stocké en session avec son id de socket
                    }
                ],
                game: {
                    inProgress: false, // état de la partie pas encore démarré
                    grid: [ // tableau de 3x3 null par défaut
                        [null, null, null],
                        [null, null, null],
                        [null, null, null]
                    ],
                    isP1Turn: true, // premier tour pour le joueur 1 par défaut
                }
            };

            rooms.push(room); // Ajoutez la room dans la liste des rooms
            socket.join(room.id);
            emitPlayerList(io, room);
            io.to(room.id).emit("id", {
                id: room.id
            });
        });

        socket.on('joinRoom', event => {
            // Si le joueur est déjà dans une room on le fait quitter
            if (roomPlayer != null) {
                rooms = handlePlayerLeave(io, socket, rooms);
            }

            if (rooms.length > 0) {
                for (let i = 0; i < rooms.length; i++) {
                    let currentRoom = rooms[i];
                    if (currentRoom.id == event.id) {
                        if (currentRoom.players.length < 2) {
                            currentRoom.players.push({ token: token, name: store.get(token).name });
                            socket.join(currentRoom.id);
                            io.to(socket.id).emit('joinedRoom', {
                                id: currentRoom.id
                            });
                            emitPlayerList(io, currentRoom);
                        } else {
                            io.to(socket.id).emit('exception', { errorMessage: `Le salon est plein` });
                        }
                    } else {
                        io.to(socket.id).emit('exception', { errorMessage: `Aucun salon n'a été trouvé avec le code renseigné` });
                    }
                }
            } else {
                io.to(socket.id).emit('exception', { errorMessage: `Aucun salon n'a été trouvé avec le code renseigné` });
            }
        });

        socket.on('leaveRoom', () => {
            rooms = handlePlayerLeave(io, socket, rooms);
        });
        //----------------------------------------------------------------------

        socket.on('startGame', () => {
            if (roomPlayer != null) {
                if (token == roomPlayer.players[0].token) {
                    if (roomPlayer.players.length == 2) {
                        io.to(roomPlayer.id).emit('startedGame', {
                            id: roomPlayer.id,
                        });

                        rooms.map(r => r.id == roomPlayer.id ? r.game.inProgress = true : r);
                    } else {
                        io.to(socket.id).emit('exception', { errorMessage: `Il faut être 2 joueurs pour lancer une partie` });
                    }
                } else {
                    io.to(socket.id).emit('exception', { errorMessage: `Vous n'êtes pas le chef du salon` });
                }
            } else {
                io.to(socket.id).emit('exception', { errorMessage: `Vous n'êtes dans aucun salon connu` });
            }
        });

        socket.on('play', cell => {
            if (roomPlayer != null) {
                if (roomPlayer.game.inProgress) {
                    let cellIndexes = cell.split(';');

                    if (roomPlayer.game.isP1Turn) {
                        if (roomPlayer.players[0].token == token) {
                            rooms.map(r => r.id == roomPlayer.id ? r.game.grid[cellIndexes[0]][cellIndexes[1]] = "P1" : r);


                        } else {
                            io.to(socket.id).emit('exception', { errorMessage: `Ce n'est pas votre tour de jouer` });
                        }
                    } else {
                        if (roomPlayer.players[1].token == token) {
                            rooms.map(r => r.id == roomPlayer.id ? r.game.grid[cellIndexes[0]][cellIndexes[1]] = "P2" : r);


                        } else {
                            io.to(socket.id).emit('exception', { errorMessage: `Ce n'est pas votre tour de jouer` });
                        }
                    }
                }
            } else {
                io.to(socket.id).emit('exception', { errorMessage: `Vous n'êtes dans aucun salon connu` });
            }
        });
    } else {
        io.to(socket.id).emit('expiredToken');
        socket.disconnect();
    }
});

server.listen(socketPort, () => {
    console.log("SocketApp listening at http://localhost:" + socketPort);
});