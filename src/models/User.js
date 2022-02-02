const Db = require('./Db.js');

class User {

    getIdUser() {
        return this.idUser;
    }

    setIdUser(idUser) {
        this.idUser = idUser;
    }

    getUsername() {
        return this.username;
    }

    setUsername(username) {
        this.username = username;
    }

    getPassword() {
        return this.password;
    }

    setPassword(password) {
        this.password = password;
    }

    /*
    async signUp() {
        let sql = "INSERT INTO users (email, password, token) VALUES (?, ?, ?)"
        Db.execute(sql, [this.getEmail(), this.getPassword(), this.getToken()], function (err) {
            if (err) throw err;
        })
    }

    async findByEmail() {
        let sql = "SELECT count(email) AS email FROM users WHERE email = ?"
        const [rows, fields] = await Db.execute(sql, [this.getEmail()]);
        return rows;
    }

    async signIn() {
        let sql = "SELECT * FROM users WHERE email = ?"
        const [rows, fields] = await Db.execute(sql, [this.getEmail()]);
        return rows;
    }
    */
}
module.exports = User;