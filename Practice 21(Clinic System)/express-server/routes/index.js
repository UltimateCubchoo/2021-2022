var express = require('express');
var router = express.Router();
var crud = require("./crud.js");

router.get("/patients", function(req, res, next){
  crud.get(req, res, "patients");
});
router.post("/insPatient", function(req, res, next) {
  console.log("INSERT PAT");
  crud.insert(req, res, "patients");
});
router.post("/updPatient", function(req, res, next){
  crud.update(req, res, "patients");
});
router.post("/delPatient", function(req, res, next){
  crud.delet(req, res, "patients");
});

router.get("/doctors", function(req, res, next){
  crud.get(req, res, "doctors");
});
router.post("/insDoctor", function(req, res, next) {
  console.log("INSERT PAT");
  crud.insert(req, res, "doctors");
});
router.post("/updDoctor", function(req, res, next){
  crud.update(req, res, "doctors");
});
router.post("/delDoctor", function(req, res, next){
  crud.delet(req, res, "doctors");
});


module.exports = router;
