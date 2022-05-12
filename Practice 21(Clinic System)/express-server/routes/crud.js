const mongodb = require('mongodb');
const mongoClient = mongodb.MongoClient;
const url = "mongodb://localhost:27017"
const dbName = "clinicdb"

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

  function search(req, res){
    var json = Object.keys(req.body)[0];
    var searchTerm = JSON.parse(json).term;
    console.log("Search Term: " + searchTerm);

    mongoClient.connect(url, {useUnifiedTopology: true}, function(err, db){
      if(err) throw err;
      var dbo = db.db(dbName);

      var patients = [];
      dbo.collection("patients").find({ $or: [{lname: searchTerm}, {fname: searchTerm}] }).toArray(function(err, data){
        if(err) throw err;
        console.log(data);
        patients = data;
      });

      var doctors = [];
      dbo.collection("doctors").find({ $or: [{lname: searchTerm}, {fname: searchTerm}] }).toArray(function(err, data){
        if(err) throw err;
        console.log(data);
        doctors = data;

        var d0 = false;
        var d1 = false;
        if(patients != [])
          d0 = true;
        if(doctors != [])
          d1 = true;
        console.log(`${patients} && ${d0}`);
        console.log(`${doctors} && ${d1}`);
        res.json(JSON.stringify({d0: d0, d1: d1}));
      });
        

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
  module.exports.search = search;
  // module.exports.convert = convert;