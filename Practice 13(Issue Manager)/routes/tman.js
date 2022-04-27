var express = require("express");
var router = express.Router();
var conn = require("../connections/conn");



/* GET users listing. */
router.get("/", function (req, res, next) {
  res.render("tman", { title: "Technicians" });
});

router.post("/add", function (req, res, next) {
  var data = req.body;
  conn.query(`INSERT INTO technicians(fname, lname, email, phone) VALUES("${data.fname}", "${data.lname}", "${data.email}", "${data.phone}")`, function (err) {
    if (err) console.log(err);
  });
  res.redirect("back");
});

router.post("/upd", function (req, res, next) {
  var data = req.body;
  conn.query(`UPDATE technicians SET fname = "${data.fname}", lname = "${data.lname}", email = "${data.email}", email = "${data.phone}" WHERE tech_id = ${data.tech_id}`, function (err) {
    if (err) console.log(err);
  });
  res.redirect("back");
});

router.post("/del", function (req, res, next) {
  var tech_id = req.body.tech_id;
  conn.query(`DELETE FROM technicians WHERE tech_id = ${tech_id}`, function (err) {
    if (err) console.log(err);
  });
  res.redirect("back");
});


module.exports = router;
