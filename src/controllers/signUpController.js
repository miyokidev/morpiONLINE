const express = require('express');
const router = express.Router();
const { checkPassword } = require('../function.js');
const User = require('../models/User.js');
const argon2 = require('argon2');
const crypto = require('crypto');

router.post('/', async (req, res) => {
    let username = req.body.username;
    let password = req.body.password;

    let message = [];

    if (!checkPassword(password)) {
        message.push("Le mot de passe doit faire minimum 8 caractères, ne doit pas contenir d'espace et doit contenir des lettres.")
    }

    if (message.length == 0) {
        password = await argon2.hash(password);

        let myUser = new User();
        myUser.setUsername(username);
        myUser.setPassword(password);

        myUser.findByUsername().then((result) => {
            if (result[0].username == 0) {
                myUser.signUp();

                res.status(201).json({
                    result: true,
                    message: "Inscription réussie !",
                })
            }
            else {
                message.push("L'adresse mail est déjà associé à un compte.")
                res.status(400).json({
                    result: false,
                    message: message
                })
            }
        });
    }
    else {
        res.status(400).json({
            result: false,
            message: message
        });
    }
})

module.exports = router;