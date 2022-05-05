var express = require('express');
var router = express.Router();
var crud = require("./crud.js");

/* GET DATA */
router.get('/clients', function(req, res, next) {
  crud.get(req, res, "clients");
});
router.get('/instructors', function(req, res, next){
  crud.get(req, res, "instructors");
});
router.get('/inscriptions', function(req, res, next){
  crud.get(req, res, "inscriptions");
});
router.get('/groups', function(res, req, next){
  crud.get(req, res, "groups");
});

/* INS DATA */
router.post('/insClient', function(req, res, next){
  crud.insert(req, res, "clients");
});
router.post('/insInstructor', function(req, res, next){
  crud.insert(req, res, "instructors");
});
router.post('/insInscription', function(req, res, next){
  // crud.convert(req, res, "inscriptions");
  crud.insert(req, res, "inscriptions");
});
router.post('/insGroup', function(req, res, next){
  crud.insert(req, res, "groups");
});

/* UPD DATA */
router.post("/updClient", function(req, res, next){
  crud.update(req, res, "clients");
});
router.post("/updInstructor", function(req, res, next){
  crud.update(req, res, "instructors");
});
router.post("/updInscription", function(req, res, next){
  crud.update(req, res, "inscriptions");
});
router.post("/updGroup", function(req, res, next){
  crud.update(req, res, "groups");
});

/*DEL DATA */
router.post("/delClient", function(req, res, next){
  crud.delet(req, res, "clients");
});
router.post("/delInstructor", function(req, res, next){
  crud.delet(req, res, "clients");
});
router.post("/delClient", function(req, res, next){
  crud.delet(req, res, "clients");
});
router.post("/delClient", function(req, res, next){
  crud.delet(req, res, "clients");
});


module.exports = router;
