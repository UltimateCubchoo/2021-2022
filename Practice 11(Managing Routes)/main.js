const express = require("express");
const app = express();
//Setting configurations for the directory of the dynamic view and the normal frontend files
app.set("view engine", "ejs");
app.set("views", (__dirname + "/views"));//Note the ejs and the other show as a html when introduced to the static folder
app.use(express.static(__dirname + "/public"));

//Using routers
const indexRouter = require("./routes/index.js");
app.use(indexRouter);

app.listen(3000, function(){//Running the server on the port
    console.log(`Server is running on port ${3000}!!`);
});