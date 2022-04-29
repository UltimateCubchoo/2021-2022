//Area Assignment

const readline = require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
});
const areas = require("./areas/areas.js");


function playResponses(type){
    if (type == 1) {
        console.log("Square");
        readline.question("Enter the length of the square: ", function (answer) {
            var area = areas.square(parseInt(answer));
            console.log("The area of your square is " + area.toString());
            return readline.close();
        });
    }
    else if (type == 2) {
        console.log("Rectangle");
        readline.question("Enter the length of the rectangle: ", function (answerl){
            var length = parseInt(answerl);
            readline.question("Enter the width of the rectangle: ", function (answerw){
                var width  = parseInt(answerw);
                var area = areas.rectangle(length, width);
                console.log("The area of your rectangle is " + area.toString());
                return readline.close();
            });
        });
    
    }
    else if (type == 3) {
        console.log("Triangle");
        readline.question("Enter the length of the triangle: ", function (answerl){
            var length = parseInt(answerl);
            readline.question("Enter the width of the rectangle: ", function (answerw){
                var width  = parseInt(answerw);
                var area = areas.triangle(length, width);
                console.log("The area of your triangle is " + area.toString());
                return readline.close();
            });
        });
    }
    
    else if (type == 4) {
        console.log("Circle");
        readline.question("Enter the radius of the circle: ", function (answer) {
            var area = areas.circle(parseInt(answer));
            console.log("The area of your circle is " + area.toString());
            return readline.close();
        });
    }
}

//Program Start
readline.question("What shape do you want to find the area of(1: square, 2: rectangle, 3: triangle, 4: circle): ", function (answer) {
    var type = parseInt(answer);
    playResponses(type);    
    });
