var express = require('express');
const fs = require("fs");
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
    console.log("faviloso");
    fs.readFileSync("images/favicon.ico", function(err, data){
        if(err) console.log(err);
        res.sendFile(data);
    })
});

module.exports = router;