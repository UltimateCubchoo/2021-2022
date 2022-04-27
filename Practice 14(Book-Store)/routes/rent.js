const express = require("express");
var router = express.Router();
console.log("rent");
router.get("/rent_view", function(req,res,next){
    res.render("rent/rent_view");
});

router.get("/rent_add", function(req,res,next){
    res.render("rent/rent_add");
})

module.exports = router;