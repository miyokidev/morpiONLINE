const store = require("./store.js");

// Check password validity and return true if everything is done
function checkPassword(password) {
    if (password != null && password != "") {
        if (password.length < 8) {
            return false;
        }

        if (!isNaN(parseInt(password))) {
            return false;
        }

        for (let i = 0; i < password.length; i++) {
            if (password[i] == " ") {
                return false;
            }
        }

        return true;
    }

    return false;
}

function checkUsername(username) {
    if (username != null && username != "") {
        if (username.length > 15) {
            return false;
        }

        for (let i = 0; i < username.length; i++) {
            if (username[i] == " ") {
                return false;
            }
        }

        return true;
    }

    return false;
}

// Génère un ID aléatoire pour la création des salons
function generateRandomId() {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    const length = 8;

    let result = '';

    const charactersLength = characters.length;
    for (let i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }

    return result;
}

// Return null if no
// Return the room if yes
function isPlayerInARoom(socket, rooms, token) {
    var room = null;

    for (let i = 0; i < rooms.length; i++) {
        let currentRoom = rooms[i];
        for (let j = 0; j < currentRoom.players.length; j++) {
            if (currentRoom.players[j].token == token && socket.id == store.get(token).id) {
                room = currentRoom;
            }
        }
    }

    return room;
}

function emitResult(io, currentRoom) {
    switch (currentRoom.game.result) {
        case 'P1':
            io.to(currentRoom.id).emit('gameEnded', {p1: "win", p2: "lose"});
            break;
        case 'P2':
            io.to(currentRoom.id).emit('gameEnded', {p1: "lose", p2: "win"});
            break;
        case 'draw':
            io.to(currentRoom.id).emit('gameEnded', {p1: "draw", p2: "draw"});
            break;
    }
}

function play(io, roomPlayer, cellIndexes, rooms) {
    rooms.map(r => r.id == roomPlayer.id ? playCell(r, cellIndexes) : r);
    io.to(roomPlayer.id).emit('gridState', roomPlayer.game.grid);
    if (isGameFinished(roomPlayer.game, cellIndexes)) {
        emitResult(io, roomPlayer);
    } else {
        io.to(roomPlayer.id).emit('isPlayer1Turn', roomPlayer.game.isP1Turn);
    }

    return rooms;
}

function playCell(room, cellIndexes) {
    if (room.game.inProgress) {
        let cell = room.game.grid[cellIndexes[0]][cellIndexes[1]];
        cell == null ? cell = (room.game.isP1Turn ? 'P1' : 'P2') : cell;
        room.game.grid[cellIndexes[0]][cellIndexes[1]] = cell;
        room.game.isP1Turn = !room.game.isP1Turn;
    }

    return room;
}

function isGameFinished(game, cellIndexes) {
    if (!game.grid.some(row => row.includes(null))) {
        game.inProgress = false;
        game.result = "draw";
        return true;
    }

    if (WhoWins(game.grid, cellIndexes[0], cellIndexes[1]) != null) {
        game.inProgress = false;
        game.result = WhoWins(game.grid, cellIndexes[0], cellIndexes[1]);
        return true;
    }

    return false;
}

function WhoWins(grid, row, col) {
    rowPlayer = checkRow(grid, row);
    colPlayer = checkCol(grid, col);
    diagPlayer = checkDiagonals(grid);

    if (rowPlayer != null) {
        return rowPlayer;
    }

    if (colPlayer != null) {
        return colPlayer;
    }

    if (diagPlayer != null) {
        return diagPlayer;
    }

    return null;
}

function checkRow(grid, row) {
    var allSame = true;
    playerCell = grid[row][0];

    for (let col = 0; col < 3; col++) {
        if (grid[row][col] != playerCell) {
            allSame = false;
        }
    }

    if (allSame) {
        return playerCell;
    }

    return null;
}

function checkCol(grid, col) {
    var allSame = true;
    playerCell = grid[0][col];

    for (let row = 0; row < 3; row++) {
        if (grid[row][col] != playerCell) {
            allSame = false;
        }
    }

    if (allSame) {
        return playerCell;
    }

    return null;
}

function checkDiagonals(grid) {
    var allSameFirstDiag = true;
    var allSameSecondDiag = true;
    var playerFirstDiag = grid[0][0];
    var playerSecondDiag = grid[2][0];

    for (let i = 0; i < 3; i++) {
        if (grid[i][i] != playerFirstDiag) {
            allSameFirstDiag = false;
        }

        if (grid[2-i][i] != playerSecondDiag) {
            allSameSecondDiag = false;
        }
    }

    if (allSameFirstDiag) {
        return playerFirstDiag;
    }

    if (allSameSecondDiag) {
        return playerSecondDiag;
    }
}

function handlePlayerLeave(io, socket, rooms) {
    var token = socket.handshake.query.token;
    var currentRoom = isPlayerInARoom(socket, rooms, token);
    if (currentRoom != null) {
        // Retire le joueur qui quitte la room.
        currentRoom.players = currentRoom.players.filter(e => e.token !== token);
        socket.leave(currentRoom.id);
        // Vérifie si le joueur est en pleine partie
        if (currentRoom.game.inProgress) {
            if (currentRoom.players[0].token == token) {
                currentRoom.game.result = "P2";
                currentRoom.game.inProgress = false;
            } else {
                currentRoom.game.result = "P1";
                currentRoom.game.inProgress = false;
            }

            emitResult(io, currentRoom);
        } else {
            // Si il n'y a plus un seul joueur dans le salon on retire l'objet room de la liste des rooms.
            if (currentRoom.players.length == 0) {
                rooms = rooms.filter(e => e !== currentRoom);
            } else {
                emitPlayerList(io, currentRoom);
            }
        }
    }
    return rooms;
}

function emitPlayerList(io, currentRoom) {
    if (currentRoom.players.length == 1) {
        var list = {
            player1: currentRoom.players[0].name,
            player2: null,
        };

        io.to(currentRoom.id).emit("playerList", list);
    } else if (currentRoom.players.length == 2) {
        io.to(currentRoom.id).emit("playerList", {
            player1: currentRoom.players[0].name,
            player2: currentRoom.players[1].name
        });
    }
}

module.exports = { checkPassword, checkUsername, generateRandomId, handlePlayerLeave, emitPlayerList, isPlayerInARoom, play };