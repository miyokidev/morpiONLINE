let btnRegister = document.getElementById("idBtnRegister");
let btnLogin = document.getElementById("idBtnLogin");

btnRegister.addEventListener("click", () => {
    let usernameRegister = document.getElementById("idUsernameRegister");
    let passwordRegister = document.getElementById("idPasswordRegister");
    let messageRegister = document.getElementById("idMessageRegister");

    let user = {
        username: usernameRegister.value,
        password: passwordRegister.value,
    }

    sendData(display, "http://10.5.47.32:8080/signup", user, messageRegister);
});

btnLogin.addEventListener("click", () => {
    let usernameLogin = document.getElementById("idUsernameLogin");
    let passwordLogin = document.getElementById("idPasswordLogin");
    let messageLogin = document.getElementById("idMessageLogin");

    let user = {
        username: usernameLogin.value,
        password: passwordLogin.value
    }

    sendData(display, "http://10.5.47.32:8080/signin", user, messageLogin);
})

async function sendData(successCallBack, link, obj, message) {
    fetch(link, { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(obj) }).then(function (response) {
        response.json().then(function (myJson) {
            successCallBack(myJson, message);
        });
    })
}

function display(data, message) {
    console.log(message);
    if(data.result == true){
        console.log("youpi");
    }
    else{
        message.innerHTML = "";
        data.message.forEach(element => {
            message.innerHTML += "<p class=\"text-danger text-left\" style=\"width: 15rem;\">"+element+"</p>";
        });
    }
}