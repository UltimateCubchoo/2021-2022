const express = require("express");
const conn = require("../connections/conn");
var router = express.Router();
router.get("/book_view", function(req,res,next){
    console.log("checkpoint");
    res.render("book/book_view");
});

router.get("/book_add", function(req,res,next){
    res.render("book/book_add");
});

router.get("/getBooks", function(req,res,next){
    conn.query("SELECT * FROM books", function(err, data){
        if(err) console.log(err);
        res.json(JSON.stringify(data));
    });
});

router.post("/postBook", function(req,res,next){
    res.end();
});

module.exports = router;