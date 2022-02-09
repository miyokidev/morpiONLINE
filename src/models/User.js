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

    async signUp() {
        let sql = "INSERT INTO users (username, password) VALUES (?, ?)"
        Db.execute(sql, [this.getUsername(), this.getPassword()], function (err) {
            if (err) throw err;
        })
    }

    async findByUsername() {
        let sql = "SELECT count(username) AS username FROM users WHERE username = ?"
        const [rows, fields] = await Db.execute(sql, [this.getUsername()]);
        return rows;
    }

    async signIn() {
        let sql = "SELECT * FROM users WHERE username = ?"
        const [rows, fields] = await Db.execute(sql, [this.getUsername()]);
        return rows;
    }

}
module.exports = User; 