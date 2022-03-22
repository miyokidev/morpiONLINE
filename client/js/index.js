const socket = io("ws://localhost:3000");

addEventListener("DOMContentLoaded", () => {
    if (sessionStorage.getItem('username') == null) {
        location.href = "form.html";
    }
});

let btnCreate = document.getElementById("idBtnCreate");
let btnJoin = document.getElementById("idBtnJoin");
let code = document.getElementById("idCode");

btnCreate.addEventListener("click", () => {
    socket.emit("createRoom", {
        name: sessionStorage.getItem('username')
    });
    socket.on("id", event => {
        location.href = "room.html?code="+event.id;
      });

});

btnJoin.addEventListener("click", () => {
    console.log(code.value);
    socket.emit("joinRoom", {
        id: code.value,
        name: sessionStorage.getItem('username')
    });
    
});

socket.on("connect", event => {
    socket.on("playerList", event => {
        console.log(event.player1);
        console.log(event.player2);
      });

      socket.on("exception", event => {
        console.log(event.errorMessage);
      });
});