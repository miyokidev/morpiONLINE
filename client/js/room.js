const socket = io("ws://localhost:7000", {
    auth :  {token: sessionStorage.getItem('token')}
});

const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
let idRoom = urlParams.get('code');

addEventListener("DOMContentLoaded", () => {
    if (sessionStorage.getItem('username') == null) {
        location.href = "form.html";
    }
    document.getElementById("idRoom").innerText = idRoom;
});

let btnStart = document.getElementById("idBtnStart");
let btnLeave = document.getElementById("idBtnLeave");
let btnCopyCode = document.getElementById("idBtnCopyCode");
let gameState = document.getElementById("gameState");

btnStart.addEventListener("click", () => {
    socket.emit('startGame');
});

socket.on('startedGame', event => {
    location.href = "game.html?code="+event.id;
});

btnLeave.addEventListener("click", () => {
    socket.emit('leaveRoom');
    location.href = "index.html";
});

btnCopyCode.addEventListener("click", () => {
    navigator.clipboard.writeText(idRoom);
});

socket.on("playerList", list => {
    document.getElementById("idPlayer1").innerText = list.player1 != null ? list.player1 : "";
    document.getElementById("idPlayer2").innerText = list.player2 != null ? list.player2 : "";
    if (list.player2 != null) {
        gameState.innerText = "Le salon est prêt";
    } else {
        gameState.innerText = "En attente d'un joueur";
    }
});

// Se reconnecter quand le token expire (crash/reboot server)
socket.on('expiredToken', () => {
    sessionStorage.clear();
    location.href = "index.html";
});

// Quand on arrive plus à se connecter au serveur socket.io (arrêt du serveur)
socket.on('connect_error', function() {
    sessionStorage.clear();
    location.href = "index.html";
 });

socket.on("exception", event => {
    let messageError = document.getElementById("idErrorMessage");

    messageError.innerHTML = `<p class="text-danger text-left">${event.errorMessage}</p>`;
});

