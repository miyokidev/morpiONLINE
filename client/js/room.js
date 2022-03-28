const socket = io("ws://10.5.47.43:7000", {
    auth :  {token: sessionStorage.getItem('token')}
});

addEventListener("DOMContentLoaded", () => {
    if (sessionStorage.getItem('username') == null) {
        location.href = "form.html";
    }
});

let btnStart = document.getElementById("idBtnStart");
let btnLeave = document.getElementById("idBtnLeave");
let gameState = document.getElementById("gameState");

btnStart.addEventListener("click", () => {
    // Start game
});

btnLeave.addEventListener("click", () => {
    socket.emit('leaveRoom');
    location.href = "index.html";
});

socket.on("playerList", list => {
    document.getElementById("idPlayer1").innerHTML = list.player1 != null ? list.player1 : "";
    document.getElementById("idPlayer2").innerHTML = list.player2 != null ? list.player2 : "";
    if (list.player2 != null) {
        gameState.innerText = "Le salon est prêt";
    } else {
        gameState.innerText = "En attente d'un joueur";
    }
});