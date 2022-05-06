const mongodb = require('mongodb');
const mongoClient = mongodb.MongoClient;
const url = "mongodb://localhost:27017"
const dbName = "first-mongo"

//CRUD ACTIONS
function get(req, res, collection){
    mongoClient.connect(url, { useUnifiedTopology: true }, function(err, db){
      if(err) throw err;
      var dbo = db.db(dbName);
      dbo.collection(collection).find().toArray(function(err, data){
        if(err) throw err;
        console.log(JSON.stringify(data));
        res.json(JSON.stringify(data));
      });
    });
  }
  
  function insert(req, res, collection){
    var json = Object.keys(req.body)[0];
    var obj = JSON.parse(json);
    console.log(obj);
    mongoClient.connect(url, {useUnifiedTopology: true}, function(err, db){
      if(err) throw err;
      else console.log("Connected...");
      var dbo = db.db(dbName);
      var clients = dbo.collection(collection);
  
      clients.insertOne(obj, function(err){
        if(err) throw err;
        console.log(" Inserted item.");
      });
  
      res.end();
    });
  }
  
  function update(req, res, collection){
    var json = Object.keys(req.body)[0];
    var obj = JSON.parse(json);
    var index = new mongodb.ObjectId(obj._id);
    delete obj._id;
    console.log(obj);
  
    mongoClient.connect(url, {useUnifiedTopology: true}, function(err, db){
      if(err) throw err;
      var dbo = db.db(dbName);
      var clients = dbo.collection(collection);
  
      clients.updateOne({_id: index}, {$set: obj}, function(err){
        if(err) throw err;
        console.log(`Updated: ${index}`);
      });
  
      res.end();
    });
  }
  
  function delet(req, res, collection){
    var json = Object.keys(req.body)[0];
    var index = JSON.parse(json).index;
    mongoClient.connect(url, {useUnifiedTopology: true}, function(err, db){
      if(err) throw err;
      var dbo = db.db(dbName);
      var clients = dbo.collection(collection);
  
      clients.deleteOne({_id: new mongodb.ObjectId(index)}, function(err){
        if(err) throw err;
        console.log(`Deleted: ${index}`);
      });
  
      res.end();
    });
  }
  
  // function convert(req, res, collection){
  //   var json = Object.keys(req.body)[0];
  //   var obj = JSON.parse(json);
  //   Object.keys(obj).forEach(function(key, i){
  //     var dateCheck = key.indexOf("date");
  //     if(dateCheck == 1){
  //       obj[key] = new mongodb.value
  //     }
  //   });
  // }

  module.exports.get = get;
  module.exports.insert = insert;
  module.exports.update = update;
  module.exports.delet = delet;
  // module.exports.convert = convert;