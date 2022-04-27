const express = require("express");
var router = express.Router();

router.get("/", function(req, res, next){
    //Trying to route index.html
    res.render("index");
});

module.exports = router;