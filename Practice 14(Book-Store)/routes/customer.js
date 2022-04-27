const express = require("express");
const conn = require("../connections/conn");
var router = express.Router();
router.get("/customer_view", function(req,res,next){
    console.log("checkpoint");
    res.render("customer/customer_view");
});

router.get("/customer_add", function(req,res,next){
    res.render("customer/customer_add");
})

router.get("/getCustomers", function(req,res,next){
    conn.query("SELECT * FROM customers", function(err, data){
        if(err) console.log(err);
        res.json(JSON.stringify(data));
    })
})

module.exports = router;