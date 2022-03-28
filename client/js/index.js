const socket = io("ws://10.5.47.43:7000", {
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

socket.on("exception", event => {
    console.log(event.errorMessage);
});