var express = require("express");
var router = express.Router();
var conn = require("../connections/conn.js");

/* GET home page. */
router.get("/", function(req, res, next) {
  res.render("index", { title: "Issue Management" });
});

router.get("/getData", function(req, res, next){
    console.log("getData");
    conn.query(`SELECT issue_id, description, status, severity, fname, lname
    FROM issues INNER JOIN technicians
    ON issues.tech_id = technicians.tech_id`, function(ierr, idata){
      if(ierr) console.log(ierr);
      var data = {};
      data["idata"] = idata;
      conn.query(`SELECT * FROM technicians`, function(terr, tdata){
        if(terr) console.log(terr);
        data["tdata"] = tdata;
        res.json(data);
      });

    });

});

module.exports = router;
