var express = require('express');
var router = express.Router();
var conn = require("../conn.js");

/* GET DATA */
router.get("/categories", function(req, res, next){
    conn.query("SELECT * FROM categories", function(err, data){
        if(err) console.log(err);
        console.log("Query was sucessfull");
        res.json(JSON.stringify(data));
    });
});
router.get("/customers", function(req, res, next) {
    conn.query("SELECT * FROM customers", function(err, data){
        if(err) console.log(err);
        console.log("Query was sucessfull");
        res.json(JSON.stringify(data));
    });
  });

router.get("/employees", function(req, res, next){
    conn.query("SELECT * FROM employees", function(err, data){
        if(err) console.log(err);
        console.log("Query was sucessfull");
        res.json(JSON.stringify(data));
    });
});

router.get("/orders", function(req, res, next){
    conn.query("SELECT order_id, date, o.shipper_id, sh.name FROM orders o INNER JOIN shippers sh ON o.shipper_id = sh.shipper_id ", function(err, data){
        if(err) console.log(err);
        console.log("Query was sucessfull");
        res.json(JSON.stringify(data));
    });
});

router.get("/products", function(req, res, next){
    conn.query("SELECT * FROM products", function(err, data){
        if(err) console.log(err);
        console.log("Query was sucessfull");
        res.json(JSON.stringify(data));
    });
});

router.get("/suppliers", function(req, res, next){
    conn.query("SELECT * FROM suppliers", function(err, data){
        if(err) console.log(err);
        console.log("Query was sucessfull");
        res.json(JSON.stringify(data));
    });
});

router.get("/shippers", function(req, res, next){
    conn.query("SELECT * FROM shippers", function(err, data){
        if(err) console.log(err);
        console.log("Query was sucessfull");
        res.json(JSON.stringify(data));
    });
});

/*INSERT DATA*/
router.post("/insCategory", function(req, res, next){
  console.log("test");
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`INSERT INTO categories(name, description) VALUES('${obj.name}', '${obj.description}')`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

router.post("/insCustomer", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`INSERT INTO customers(fname, lname, address, phone, city, zip) VALUES('${obj.fname}', '${obj.lname}', '${obj.address}', '${obj.phone}', '${obj.city}', '${obj.zip}')`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

router.post("/insEmployee", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`INSERT INTO employees(fname, lname, email, birthdate) VALUES('${obj.fname}', '${obj.lname}', '${obj.email}', '${obj.birthdate}')`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

router.post("/insOrder", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`INSERT INTO orders(date, shipper_id) VALUES('${obj.date}', '${obj.shipper_id}')`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

router.post("/insProduct", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`INSERT INTO products(name, unit, price) VALUES('${obj.name}', '${obj.unit}', '${obj.price}')`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

router.post("/insShipper", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`INSERT INTO shippers(name, phone) VALUES('${obj.name}', '${obj.phone}')`, function(err){
    if(err) console.log(err);
  });
  res.end();
});

router.post("/insSupplier", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`INSERT INTO suppliers(name, address, phone, city, zip) VALUES('${obj.name}', '${obj.address}', '${obj.phone}', '${obj.city}', '${obj.zip}')`, function(err){
    if(err) console.log(err);
  });
  res.end();
});



/*UPDATE DATA*/
router.post("/updCategory", function(req, res, next){
  var params = req.body;
  var json = Object.keys(params)[0];
  console.log(json);
  var obj = JSON.parse(json);
  conn.query(`UPDATE categories SET name = '${obj.name}', description = '${obj.description}' WHERE category_id = '${obj.category_id}'`, function(err){
    if(err) console.log(err);
  });
  res.end();
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

router.post("/updEmployee", function(req, res, next){
    var params = req.body;
    var json = Object.keys(params)[0];
    console.log(json);
    var obj = JSON.parse(json);
    conn.query(`UPDATE employees SET fname = '${obj.fname}', lname = '${obj.lname}', email = '${obj.email}', birthdate = '${obj.birthdate}' WHERE employee_id = '${obj.employee_id}'`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });
  
  router.post("/updOrder", function(req, res, next){
    var params = req.body;
    var json = Object.keys(params)[0];
    console.log(json);
    var obj = JSON.parse(json);
    conn.query(`UPDATE orders SET date = '${obj.date}', shipper_id = '${obj.shipper_id}' WHERE order_id = '${obj.order_id}'`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });

  router.post("/updProduct", function(req, res, next){
    var params = req.body;
    var json = Object.keys(params)[0];
    console.log(json);
    var obj = JSON.parse(json);
    conn.query(`UPDATE products SET name = '${obj.name}', unit = '${obj.unit}', price = '${obj.price}' WHERE product_id = '${obj.product_id}'`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });

  router.post("/updShipper", function(req, res, next){
    var params = req.body;
    var json = Object.keys(params)[0];
    console.log(json);
    var obj = JSON.parse(json);
    conn.query(`UPDATE shippers SET name = '${obj.name}', phone = '${obj.phone}' WHERE shipper_id = '${obj.shipper_id}'`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });

  router.post("/updSupplier", function(req, res, next){
    var params = req.body;
    var json = Object.keys(params)[0];
    console.log(json);
    var obj = JSON.parse(json);
    conn.query(`UPDATE suppliers SET name = '${obj.name}', address = '${obj.address}', phone = '${obj.phone}', city = '${obj.city}', zip = '${obj.zip}'  WHERE supplier_id = '${obj.supplier_id}'`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });


  /*DELETE DATA*/
  router.post("/delCategory", function(req, res, next){
    var params = req.body;
    var index = parseInt(Object.keys(params)[0]);
    conn.query(`DELETE FROM categories WHERE category_id = ${index}`, function(err){
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

  router.post("/delEmployee", function(req, res, next){
    var params = req.body;
    var index = parseInt(Object.keys(params)[0]);
    conn.query(`DELETE FROM employees WHERE employee_id = ${index}`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });

  router.post("/delOrder", function(req, res, next){
    var params = req.body;
    var index = parseInt(Object.keys(params)[0]);
    conn.query(`DELETE FROM orders WHERE order_id = ${index}`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });

  router.post("/delProduct", function(req, res, next){
    var params = req.body;
    var index = parseInt(Object.keys(params)[0]);
    conn.query(`DELETE FROM products WHERE product_id = ${index}`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });

  router.post("/delShipper", function(req, res, next){
    var params = req.body;
    var index = parseInt(Object.keys(params)[0]);
    conn.query(`DELETE FROM shippers WHERE shipper_id = ${index}`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });

  router.post("/delSupplier", function(req, res, next){
    var params = req.body;
    var index = parseInt(Object.keys(params)[0]);
    conn.query(`DELETE FROM suppliers WHERE supplier_id = ${index}`, function(err){
      if(err) console.log(err);
    });
    res.end();
  });



module.exports = router;
