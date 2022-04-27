var express = require('express');
var router = express.Router();
const conn = require("../conn.js");
const formidable = require('formidable');
const fs = require("fs");


/* GET DATA. */
router.get("/bookAll", function(req, res, next) {
  conn.query("SELECT * FROM BOOKS", function (err, data){
    if(err) console.log(err);
    console.log(data);
    res.json(JSON.stringify(data));
  });
});

router.get("/bookBest", function(req, res, next){
  conn.query("SELECT * FROM BOOKS ORDER BY rating DESC LIMIT 4", function (err, data){
    if(err) console.log(err);
    console.log(data);
    res.json(JSON.stringify(data));
  });
});

router.get("/bookComing", function(req, res, next){
  conn.query("SELECT * FROM BOOKS WHERE COMING = TRUE", function(err, data){
    if(err) console.log(err);
    console.log(data);
    res.json(JSON.stringify(data));
  });
});


router.get("/author", function(req, res, next){
  conn.query("SELECT AUTHOR FROM BOOKS", function(err, data){
    if(err) console.log(err);
    console.log(data);
    res.json(JSON.stringify(data));
  });
})

router.get("/customer", function(req, res, next) {
  conn.query("SELECT * FROM CUSTOMERS", function(err, data){
    if(err) console.log(err);
    console.log(data);
    res.json(JSON.stringify(data));
  })
});

router.get("/rent", function(req, res, next){
  conn.query("SELECT * FROM RENTS", function(err, data){
    if(err) console.log(err);
    console.log(data);
    res.json(JSON.stringify(data));
  })
});

/*INSERT DATA*/
router.post("/insBook", function(req, res, next){/*PROBLEM RIGHT HERE*/
  var form = new formidable.IncomingForm();
  form.parse(req, function(name, file){
    console.log("Parsed");
    /*Image Saving*/
    var imgStr = file["image"];
    var dataIndex = imgStr.indexOf(',') + 1;
    imgStr = imgStr.slice(dataIndex, imgStr.length);
    var imgBuffer = Buffer.from(imgStr, "base64");
    var imgName = `${file["title"]}.png`;
    fs.writeFile(`public/images/${imgName}`, imgBuffer, function(err){
      if(err) console.log(err);
    });

    /*Rest of the sql Saving*/
    conn.query(`INSERT INTO books(title, author, genre, rating, image) VALUES('${file["title"]}', '${file["author"]}', '${file["genre"]}', '${file["rating"]}', '${imgName}')`, function(err){
      if(err) console.log(err);
      else console.log("Insertion was sucessful");
    })
    res.end();
  })
});


router.post("/insCustomer", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`INSERT INTO customers(fname, lname, address, phone) VALUES('${obj.fname}', '${obj.lname}', '${obj.address}', '${obj.phone}')`, function(err){
    if(err) console.log(err);
  });
  res.end();
});


router.post("/insRent", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`INSERT INTO rents(indate, outdate) VALUES('${obj.indate}', '${obj.outdate}')`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

/*UPDATE DATA*/
router.post("/updBook", function(req, res, next){
  console.log("/updBOOKS");
  var form = new formidable.IncomingForm();
  form.parse(req, function(name, file){
    console.log("Parsed");
    console.log(file);
    /*Image Saving*/
    var imgStr = file["image"];
    var dataIndex = imgStr.indexOf(',') + 1;
    imgStr = imgStr.slice(dataIndex, imgStr.length);
    var imgBuffer = Buffer.from(imgStr, "base64");
    var imgName = `${file["title"]}.png`;
    fs.writeFile(`public/images/${imgName}`, imgBuffer, function(err){
      if(err) console.log(err);
    });

    /*Rest of the sql Saving*/
    conn.query(`UPDATE books SET title = '${file["title"]}', author = '${file["author"]}', genre = '${file["genre"]}', rating = '${file["rating"]}', image = '${imgName}' WHERE book_id = '${file["book_id"]}'`, function(err){
      if(err) console.log(err);
      else console.log("UPDATE was sucessfull");
    });
    res.end();
  });
});

router.post("/updCustomer", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`UPDATE customers SET fname = '${obj.fname}', lname = '${obj.lname}', address = '${obj.address}', phone = '${obj.phone}'  WHERE customer_id = '${obj.customer_id}'`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

router.post("/updRent", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`UPDATE rents SET indate = '${obj.indate}', outdate = '${obj.outdate}' WHERE rent_id = '${obj.rent_id}'`, function(err){
    if(err) console.log(err);
  });
  res.end();
});


/*DELETE DATA*/
router.post("/delBook", function(req, res, next){
  var params = req.body;
  var index = parseInt(Object.keys(params)[0]);
  conn.query(`DELETE FROM books WHERE book_id = ${index}`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

router.post("/delCustomer", function(req, res, next){
  var params = req.body;
  var index = parseInt(Object.keys(params)[0]);
  conn.query(`DELETE FROM customers WHERE customer_id = ${index}`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

router.post("/delRent", function(req, res, next){
  var params = req.body;
  var index = parseInt(Object.keys(params)[0]);
  conn.query(`DELETE FROM rents WHERE rent_id = ${index}`, function(err){
    if(err) console.log(err);
  });
  res.end();
});


module.exports = router;
