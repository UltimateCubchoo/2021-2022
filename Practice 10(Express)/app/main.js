const express = require("express");
const app = express();
const fs = ("fs");
///This line imports into a varible the file JSON
var dataFile = require("./data.json");

//port can bec ahge through the environment processes
var port = process.env.PORT || 4000;
app.set("port", port);
app.get("/", function(req, res){
    var info = "";
    dataFile.speakers.forEach(function(item){
        info += `<li style="list-style-type: none">
                        <h2>${item.name}</h2>
                        <p>${item.summary}</p>
                    </li>`
    });
    res.write("<h1>Working with environment variables</h1>");
    res.write(info);
    res.end();
});

app.use(express.static(__dirname + "/public"));

var server = app.listen(3000, () => {
    console.log('Server listening on port 3000');
});