let btnRegister = document.getElementById("idBtnRegister");
let btnLogin = document.getElementById("idBtnLogin");

const user = {};

addEventListener("DOMContentLoaded", () => {
    if(sessionStorage.getItem('username') != null) {
        location.href = "index.html";
    }
});

btnRegister.addEventListener("click", () => {
    let usernameRegister = document.getElementById("idUsernameRegister");
    let passwordRegister = document.getElementById("idPasswordRegister");
    let messageRegister = document.getElementById("idMessageRegister");

    user.username = usernameRegister.value;
    user.password = passwordRegister.value;

    sendData(display, "http://localhost:6969/signup", user, messageRegister);
});

btnLogin.addEventListener("click", () => {
    let usernameLogin = document.getElementById("idUsernameLogin");
    let passwordLogin = document.getElementById("idPasswordLogin");
    let messageLogin = document.getElementById("idMessageLogin");

    user.username = usernameLogin.value;
    user.password = passwordLogin.value;

    sendData(display, "http://localhost:6969/signin", user, messageLogin);
})

async function sendData(successCallBack, link, obj, message) {
    fetch(link, { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(obj) }).then(function (response) {
        response.json().then(function (myJson) {
            successCallBack(myJson, message);
        });
    })
}

function display(data, message) {
    message.innerHTML = "";
    if (data.result == true) {
        sessionStorage.setItem('username', user.username);
        sessionStorage.setItem('token', data.token);
        message.innerHTML += "<p class=\"text-success text-left\" style=\"width: 15rem;\">" + data.message + "</p>";

        
        setTimeout(() => {
            location.href = "index.html";
        }, 1000);
    }
    else {
        data.message.forEach(element => {
            message.innerHTML += "<p class=\"text-danger text-left\" style=\"width: 15rem;\">" + element + "</p>";
        });
    }
}