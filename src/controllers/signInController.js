const express = require('express');
const router = express.Router();
const { checkPassword, checkUsername } = require('../function.js');
const User = require('../models/User.js');
const argon2 = require('argon2');
const crypto = require('crypto');
const dotenv = require('dotenv').config();

router.post('/', (req, res) => {
    let username = req.body.username;
    let password = req.body.password;

    let message = [];

    if (!checkUsername(username)) {
        message.push("Le nom d'utilisateur que vous avez saisi est incorrect.")
    }

    if (!checkPassword(password)) {
        message.push("Le mot de passe que vous avez saisi est incorrect.")
    }

    if (message.length == 0) {
        let myUser = new User();
        myUser.setUsername(username);
        myUser.setPassword(password);

        myUser.signIn().then(async (response) => {
            if (response.length != 0) {
                if (response[0].username == myUser.getUsername() && await argon2.verify(response[0].password, myUser.getPassword())) {
                    myUser.setIdUser(response[0].idUser);
                    res.status(200).json({
                        result: true,
                        message: "Connexion réussie !",
                        socketPort: process.env.SOCKET_PORT,
                    })
                }
                else {
                    message.push("Le mot de passe que vous avez saisi est incorrect.")
                    res.status(400).json({
                        result: false,
                        message: message
                    });
                }
            }
            else {
                message.push("Le nom d'utilisateur que vous avez saisi n'est pas enregistré.")
                res.status(400).json({
                    result: false,
                    message: message
                });
            }
        })

    }
    else {
        res.status(400).json({
            result: false,
            message: message
        });
    }
})

module.exports = router;