const mysql = require("mysql");
var conn = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "root",
    database: "computerstoredb"
});

module.exports = conn;