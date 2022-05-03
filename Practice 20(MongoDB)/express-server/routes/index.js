var express = require('express');
var router = express.Router();
const mongodb = require('mongodb');
const mongoClient = mongodb.MongoClient;
const url = "mongodb://localhost:27017/first-mongo"

router.get("/test", function(req, res, next){
  console.log("THIS IS A TEST");
  res.end();
});

/* GET DATA */

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

router.get('instructors', function(req, res, next){
  mongoClient.connect(url, { useUnifiedTopology: true }, function(err, db){
    if(err) throw err;
    let dbo = db.db("first-mongo");
    dbo.collection("instructors").find().toArray(function(err, data){
      if(err) throw err;
      console.log(JSON.stringify(data));
      res.json(JSON.stringify(data));
    });
  });
});

/* INS DATA */
router.post('/insClient', function(req, res, next){
  let params = req.body;
  mongoClient.connect(url, {useUnifiedTopology: true}, function(err, db){
    if(err) throw err;
    let dbo = db.db("first-mongo");
    dbo.collection.insert();
  });
});

/* UPD DATA */

/*DEL DATA */
router.post("del", function(req, res, next){
  let params = req.body;
  console.log(params);
  res.end();
});

module.exports = router;
