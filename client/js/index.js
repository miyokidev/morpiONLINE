const socket = io("ws://localhost:7000", {
    auth :  {token: sessionStorage.getItem('token')}
});

addEventListener("DOMContentLoaded", () => {
    if (sessionStorage.getItem('username') == null) {
        location.href = "form.html";
    }
});

let btnCreate = document.getElementById("idBtnCreate");
let btnJoin = document.getElementById("idBtnJoin");
let code = document.getElementById("idCode");

btnCreate.addEventListener("click", () => {
    socket.emit("createRoom");

    socket.on("id", event => {
        location.href = "room.html?code="+event.id;
      });
});

btnJoin.addEventListener("click", () => {
    socket.emit("joinRoom", {
        id: code.value,
    });
    
    socket.on('joinedRoom', event => {
        location.href = "room.html?code="+event.id;
    });
});

socket.on('exception', event => {
    let messageError = document.getElementById("idErrorMessage");
    messageError.innerHTML = `<p class="text-danger text-left">${event.errorMessage}</p>`;
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