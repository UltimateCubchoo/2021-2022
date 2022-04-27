var express = require('express');
const conn = require('../connections/conn');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.render("about", {title: "Express"});
});

router.get("/getData", function (req, res, next){
  conn.query("SELECT * FROM books", function (err, data){
    if(err) console.log(err);
    res.json(data);
  });
});

router.post("/delItem", function(req, res, next){
  //Getting the specific index of the panel we are given
  var index = req.body.index;
  console.log(index);
  conn.query(`DELETE FROM books WHERE book_id = ${index}`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

module.exports = router;
