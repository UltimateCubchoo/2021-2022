var express = require('express');
const conn = require('../connections/conn'); //Using our made connection in our router
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: "Book Management System" });
});

/* Get Table Data */
router.get("/getData", function (req, res, next){
  conn.query("SELECT * FROM books", function (err, data){
    if(err) console.log(err);
    res.json(data);
  });
});

module.exports = router;
