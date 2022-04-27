var express = require('express');
var router = express.Router();
const conn = require("../connections/conn.js")

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Book-Store', books: {}});
});

router.get("/getIndex", function(req, res, next){
  conn.query("SELECT * FROM books WHERE coming = 0 ORDER BY rating ASC LIMIT 4", function(err, pack1){
    if(err) console.log(err);
    var data = {};
    data["best_seller"] = pack1;

    conn.query(`SELECT * FROM books WHERE coming = 1`, function(err, pack2){
      data["coming_soon"] = pack2;
      res.json(JSON.stringify(data));
    });
  });
});

module.exports = router;