const socket = io("ws://localhost:7000", {
    auth :  {token: sessionStorage.getItem('token')}
});

addEventListener("DOMContentLoaded", () => {
    if(sessionStorage.getItem('username') == null) {
        location.href = "form.html";
    }
});

const cells = document.querySelectorAll('td');
for (var i = 0; i < cells.length; i++) {
    cells[i].addEventListener('click', function (e) {
      socket.emit('play', e.target.id);
    });
}

socket.on("playerList", list => {
    let myName = sessionStorage.getItem('username');

    if (list.player1 == myName) {
        document.getElementById("idSymbolP1").innerText = "Vous";
        document.getElementById("idSymbolP2").innerText = list.player2;
    } else {
        document.getElementById("idSymbolP1").innerText = list.player1;
        document.getElementById("idSymbolP2").innerText = "Vous"; 
    }
});

socket.on("isPlayer1Turn", isP1Turn => {
    document.getElementById("idSymbolP1").classList.remove("fw-bold");
    document.getElementById("idSymbolP2").classList.remove("fw-bold");

    if (isP1Turn) {
        document.getElementById("idSymbolP1").classList.add("fw-bold");
    } else {
        document.getElementById("idSymbolP2").classList.add("fw-bold");
    }
});

// Se reconnecter quand le token expire (crash/reboot server)
socket.on('expiredToken', () => {
    sessionStorage.clear();
    location.href = "index.html";
});

socket.on("exception", event => {
    //let messageError = document.getElementById("idErrorMessage");
    //messageError.innerHTML = `<p class="text-danger text-left">${event.errorMessage}</p>`;
    console.log(event.errorMessage);
});