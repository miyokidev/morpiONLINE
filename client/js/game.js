const token = sessionStorage.getItem('token');
const socket = io("ws://localhost:7000", {
    query: {token}
});

addEventListener("DOMContentLoaded", () => {
    if (sessionStorage.getItem('username') == null) {
        location.href = "form.html";
    }
});

const cells = document.querySelectorAll('td');
for (var i = 0; i < cells.length; i++) {
    cells[i].addEventListener('click', function (e) {
        if (e.target.id.split(";").length == 2) {
            socket.emit('play', e.target.id);
        }
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

socket.on('gridState', grid => {
    let blank = "img/blanc.png";
    let p1Symbol = "img/croix.png";
    let p2Symbol = "img/rond.png";

    for (let i = 0; i < grid.length; i++) {
        for (let j = 0; j < grid[i].length; j++) {
            switch (grid[i][j]) {
                case 'P1':
                    document.getElementById(i + ";" + j).src = p1Symbol;
                    break;
                case 'P2':
                    document.getElementById(i + ";" + j).src = p2Symbol;
                    break;
                default:
                    document.getElementById(i + ";" + j).src = blank;
                    break;
            }
        }
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

// Quand on arrive plus à se connecter au serveur socket.io (arrêt du serveur)
socket.on('connect_error', function () {
    sessionStorage.clear();
    location.href = "index.html";
});