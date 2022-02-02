const express = require('express');
const router = express.Router();
const { checkPassword } = require('../function.js');
const User = require('../models/User.js');
const argon2 = require('argon2');
const crypto = require('crypto');

router.post('/', async (req, res) => {
    let email = req.body.email.trim().toLowerCase();
    let password = req.body.password;

    let message = [];

    if (!checkPassword(password)) {
        message.push("Le mot de passe doit faire minimum 8 caractères, ne doit pas contenir d'espace et doit contenir des lettres.")
    }

    if (!checkEmail(email)) {
        message.push("L'adresse email que vous avez saisit est incorrect.")
    }

    if (message.length == 0) {
        password = await argon2.hash(password);
        // Génère une chaine de caractères de 40 caractères
        let token = crypto.randomBytes(20).toString('hex')

        let myUser = new User(email, password, token)

        myUser.findByEmail().then((result) => {
            if (result[0].email == 0) {
                myUser.signUp();

                res.status(201).json({
                    result: true,
                    message: "Inscription réussie !",
                    token: myUser.token
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