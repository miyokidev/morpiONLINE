const express = require('express');
const dotenv = require('dotenv').config();
const signIn = require('./controllers/signInController.js');
const signUp = require('./controllers/signUpController.js');
const { generateRandomId, handlePlayerLeave } = require('./function.js');

const app = express();
const port = process.env.PORT;

const socketApp = express();
const socketPort = process.env.SOCKET_PORT;

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

var server = require('http').createServer(socketApp);
var io = require('socket.io')(server, {
    cors: {    
        origin: "*",
    }
});

let rooms = [];

io.on('connection', (socket) => {

    console.log('Connected: ' + socket.id);

    socket.on('disconnect', () => {
        rooms = handlePlayerLeave(socket, rooms);
        console.log('Disconnected: ' + socket.id);
    });

    socket.on('createRoom', event => {
        const room = {
            id: generateRandomId(),
            players: [socket.id],
        };

        rooms.push(room);
        socket.join(room.id);
    });

    socket.on('joinRoom', event => {
        for (let i = 0; i < rooms.length; i++) {
            let currentRoom = rooms[i];
            if (currentRoom.id == event.id) {
                if (currentRoom.players.length < 2) {
                    currentRoom.players.push(socket.id);
                    socket.join(currentRoom.id);
                } else {
                    socket.emit('exception', {errorMessage: `Le salon est plein`});
                }
            } else {
                socket.emit('exception', {errorMessage: `Aucun salon n'a été trouvé avec le code renseigné`});
            }
        }
    });

    socket.on('leaveRoom', () => {
        rooms = handlePlayerLeave(socket, rooms);
    });

    socket.on('showPublicRooms', () => {
        
    });
});

server.listen(socketPort, () => {
    console.log("SocketApp listening at http://localhost:" + socketPort);
});