function checkPassword(password) {
    if (password.length < 8) {
        return false;
    }

    if(!isNaN(parseInt(password))) {
        return false;
    }

    for (let i = 0; i < password.length; i++) {
        if (password[i] == " ") {
            return false;
        }
    }
    return true;
}

module.exports = { checkPassword };