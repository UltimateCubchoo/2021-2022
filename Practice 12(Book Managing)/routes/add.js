var express = require('express');
var router = express.Router();
const formidable = require('formidable');
var multiparty = require("multiparty");
const conn = require('../connections/conn');
const fs = require("fs");

//Default router request for the page when loading in
//The page loads in the 
router.get('/', function(req, res, next){
    res.render('add', {title: 'Add a book'});
});

//Get the submission of a book
router.post("/sendObb", function(req, res, next){
    /* Uploading the image into our public folder 
        !Formidable Usage*/
    console.log("Phase 1");//Point 1
    
    //Configuring formidable
    var input = new formidable.IncomingForm();
    input.uploadDir = "images";
    input.parse(req);
    //Saving the image and me messing with the file properties in formidable
    input.on("fileBegin", function(fields, file){
        var filename = file.originalFilename;//Just the name of the actual file
        var filepath = file.filepath;//Includes the directory of the file and a string
        var filenew = file.newFilename;//Includes the bit string
        console.log("filename: " + filename + ", filepath: " + filepath
         + ", filenew: " + filenew);//Making sure that the file is here and intilized.
        file.filepath = "public/images/" +  filename;//Let's see if this moves it
    });
    input.on("file", function(field, file){
        console.log("Uploaded: " + file.name);
    });

    /* Turning our FormData from our request back into an object
        !Multiparty Usage */
    console.log("Phase 2...");
    var formData = new multiparty.Form();
    formData.parse(req, function(err, fields, files){
        var rowData = [
            fields.title,
            fields.author,
            files.image[0].originalFilename,
            fields.description
        ];
        console.log(rowData);

        //Uploading our data into our database
        conn.query(`INSERT INTO books(title, author, image, description) VALUES("${rowData[0]}", "${rowData[1]}", "${rowData[2]}", "${rowData[3]}")`
        , function(err){
            if(err) console.log(err);
        });
        
    });
    console.log("Done!!");

    res.end();
});


module.exports = router;