const express = require('express');
const dotenv = require('dotenv').config();
const signIn = require('./controllers/signInController.js');
const signUp = require('./controllers/signUpController.js');
const { generateRandomId, handlePlayerLeave, emitPlayerList } = require('./function.js');
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

    console.log('Connected: ' + socket.id);

    // On vérifie si l'utilisateur nous renseigne un token existant dans la mémoire.
    if (store.get(socket.handshake.auth.token) != null) {
        var token = socket.handshake.auth.token;
        // Refresh socket id of user by token
        var user = store.get(token);
        user.id = socket.id;
        store.set(token, user);

        socket.on('disconnect', () => {
            rooms = handlePlayerLeave(io, socket, rooms);
            console.log('Disconnected: ' + socket.id);
        });
    
        socket.on('createRoom', () => {
            var token = socket.handshake.auth.token;

            const room = {
                id: generateRandomId(),
                players: [{token : token, name: store.get(token).name}],
            };
    
            rooms.push(room);
            socket.join(room.id);
            emitPlayerList(io, room);
            io.to(room.id).emit("id", {
                id: room.id
            });
        });
    
        socket.on('joinRoom', event => {
            for (let i = 0; i < rooms.length; i++) {
                let currentRoom = rooms[i];
                if (currentRoom.id == event.id) {
                    if (currentRoom.players.length < 2) {
                        currentRoom.players.push({token: event.token, name: store.get(event.token).name});
                        socket.join(currentRoom.id);
                        emitPlayerList(io, currentRoom);
                    } else {
                        io.to(socket.id).emit('exception', {errorMessage: `Le salon est plein`});
                    }
                } else {
                    io.to(socket.id).emit('exception', {errorMessage: `Aucun salon n'a été trouvé avec le code renseigné`});
                }
            }
        });
    
        socket.on('leaveRoom', () => {
            rooms = handlePlayerLeave(io, socket, rooms);
        });
    } else {
        socket.disconnect();
        io.to(socket.id).emit('exception', {errorMessage: `Token non valide`});
    }
});

server.listen(socketPort, () => {
    console.log("SocketApp listening at http://localhost:" + socketPort);
});