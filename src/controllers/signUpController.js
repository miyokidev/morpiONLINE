const express = require('express');
const router = express.Router();
const { checkPassword, checkUsername } = require('../function.js');
const User = require('../models/User.js');
const argon2 = require('argon2');
const crypto = require('crypto');
const store = require('../store.js');

router.post('/', async (req, res) => {
    let username = req.body.username;
    let password = req.body.password;

    let message = [];

    if (!checkUsername(username)) {
        message.push("Le nom d'utilisateur doit faire maximum 8 caractères et ne doit pas contenir d'espace.")
    }

    if (!checkPassword(password)) {
        message.push("Le mot de passe doit faire minimum 8 caractères, ne doit pas contenir d'espace et doit contenir des lettres.")
    }

    if (message.length == 0) {
        password = await argon2.hash(password);

        // Génère une chaine de caractères de 40 caractères
        let token = crypto.randomBytes(20).toString('hex')

        let myUser = new User();
        myUser.setUsername(username);
        myUser.setPassword(password);

        myUser.findByUsername().then((result) => {
            if (result[0].username == 0) {
                myUser.signUp();

                res.status(201).json({
                    result: true,
                    message: "Inscription réussie !",
                    token: token
                });

                const user = {
                    id: null,
                    name: myUser.getUsername()
                };

                store.set(token, user);
            }
            else {
                message.push("Le nom d'utilisateur est déjà associé à un compte.")
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