const express = require('express');
const signIn = require('./controllers/signInController.js');
const signUp = require('./controllers/signUpController.js');

const app = express();
const port = 6969;

const socketApp = express();
const socketPort = 3000;

app.use(function (req, res, next) {
    res.setHeader('Access-Control-Allow-Origin', '*')
    res.setHeader('Access-Control-Allow-Methods', 'GET, PUT, POST, DELETE')
    res.setHeader('Access-Control-Allow-Headers', 'Authorization')
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

// a new client is connected
io.on('connection', (socket) => {

    console.log('Connected: ' + socket.id);

    socket.on('disconnect', () => {
        console.log('Disconnected: ' + socket.id);
    });

    socket.on('hello', event => {
        socket.broadcast.emit('hello', event);
    });

    socket.on('message', event => {
        io.emit('message', event);
    });

});

server.listen(socketPort, () => {
    console.log("SocketApp listening at http://localhost:" + socketPort);
});