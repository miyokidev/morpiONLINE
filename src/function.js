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

function handlePlayerLeave(io, player, rooms) {
    for (let i = 0; i < rooms.length; i++) {
        let currentRoom = rooms[i];
        for (let j = 0; j < currentRoom.players.length; j++) {
            if (currentRoom.players[j].id == player.id) {
                // Retire le joueur qui quitte la room.
                currentRoom.players = currentRoom.players.filter(e => e.id !== player.id);
                player.leave(currentRoom.id);

                // Si il n'y a plus un seul joueur dans le salon on retire l'objet room de la liste des rooms.
                if (currentRoom.players.length == 0) {
                    rooms = rooms.filter(e => e !== currentRoom);
                } else {
                    emitPlayerList(io, currentRoom);
                }
            }
        }
    }
    return rooms;
}

function emitPlayerList(io, currentRoom) {
    if (currentRoom.players.length == 1) {
        var list = {
            playerOne: "name1",
            playerTwo: "name2",
            playerThree: "name3",
        };

        io.to(currentRoom.id).emit("playerList", list);
    } else if (currentRoom.players.length == 2) {
        io.to(currentRoom.id).emit("playerList", {
            player1: currentRoom.players[0].name,
            player2: currentRoom.players[1].name
        });
    }
}

module.exports = { checkPassword, checkUsername, generateRandomId, handlePlayerLeave, emitPlayerList };