var express = require('express');
var router = express.Router();
const mongodb = require('mongodb');
const mongoClient = mongodb.MongoClient;
const url = "mongodb://localhost:27017/first-mongo"

/* Mongo Actions */
router.get('/clients', function(req, res, next) {
  mongoClient.connect(url, { useUnifiedTopology: true }, function(err, db){
    if(err) throw err;
    let dbo = db.db("first-mongo");
    dbo.collection("clients").find().toArray(function(err, data){
      if(err) throw err;
      console.log(JSON.stringify(data));
      res.json(JSON.stringify(data));
    });
  });
});

module.exports = router;
