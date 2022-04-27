const mysql = require("mysql");
var conn = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "root",
    database: "bkstoredb"
});

conn.connect(function(err){
    if(err) console.log(err);
});

module.exports = conn;