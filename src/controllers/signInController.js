const express = require('express');
const router = express.Router();
const { checkPassword } = require('../function.js');
const User = require('../models/User.js');
const argon2 = require('argon2');
const crypto = require('crypto');

router.post('/', (req, res) => {
    let email = req.body.email//.trim().toLowerCase();
    let password = req.body.password;

    let message = [];

    if (!checkPassword(password)) {
        message.push("Le mot de passe doit faire minimum 8 caractères, ne doit pas contenir d'espace et doit contenir des lettres.")
    }

    if (!checkEmail(email)) {
        message.push("L'adresse email que vous avez saisit est incorrect.")
    }

    if (message.length == 0) {
        // Génère une chaine de caractères de 40 caractères
        let token = crypto.randomBytes(20).toString('hex')
        let myUser = new User(email, password, token)

        myUser.signIn().then(async (response) => {
            if (response.length != 0) {
                if (response[0].email == myUser.getEmail() && await argon2.verify(response[0].password, myUser.getPassword())) {
                    myUser.setIdUser(response[0].idUser);
                    myUser.changeToken()
                    res.status(200).json({
                        result: true,
                        message: "Connexion réussie !",
                        token: myUser.getToken()
                    })
                }
                else {
                    message.push("Le mot de passe que vous avez saisit est incorrect.")
                    res.status(400).json({
                        result: false,
                        message: message
                    });
                }
            }
            else {
                message.push("L'adresse email que vous avez saisit n'est pas enregistré.")
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