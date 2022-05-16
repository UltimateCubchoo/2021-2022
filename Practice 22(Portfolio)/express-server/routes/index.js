var express = require('express');
var router = express.Router();
const mongodb = require("mongodb");
const mongoClient = mongodb.MongoClient;
const url = "mongodb://localhost:27017"
const dbName = "";

/* GET home page. */
router.get('/projects', function(req, res, next) {
  try {
    mongoClient.connect(url, {useUnifiedTopology: true}, function(err, db){
      if(err) throw err;
      var dbo = db.db(dbName);
      dbo.collection("projects").find().toArray(function(err, data){
        if(err) throw err;
        res.json(JSON.stringify(data));
      });
    });
  } catch (err) {
    console.log("Error: " + err);
    res.send(404);
  }
});

module.exports = router;
