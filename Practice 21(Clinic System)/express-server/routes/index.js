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

router.get("/appointments", function(req, res, next){
  crud.get(req, res, "appointments");
});
router.post("/insAppointment", function(req, res, next){
  crud.insert(req, res, "appointments");
});
router.post("/updAppointment", function(req, res, next){
  crud.update(req, res, "appointments");
});
router.post("/delAppointment", function(req, res, next){
  crud.delet(req, res, "appointments");
});

router.get("/users", function(req, res, next){
  crud.get(req, res, "users");
});
router.post("/insUser", function(req, res, next){
  console.log("insUsers time");
  crud.insert(req, res, "users");
});
router.post("/updUser", function(req, res, next){
  crud.update(req, res, "users");
});
router.post("/delUser", function(req, res, next){
  crud.delet(req, res, "users");
});

router.post("/search", function(req, res, next){
  crud.search(req, res);
});

module.exports = router;
