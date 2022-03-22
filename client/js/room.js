const socket = io("ws://localhost:3000");
let username1 = document.getElementById("idUsername1");

addEventListener("DOMContentLoaded", () => {
    if(sessionStorage.getItem('username') == null) {
        location.href = "form.html";
    }
    else {
        username1.textContent = sessionStorage.getItem('username');
    }
});