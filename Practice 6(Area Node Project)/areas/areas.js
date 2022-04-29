module.exports = {
    square:
        function(length){
            return length * length;
        },
    rectangle:
        function(length, width){
            return length * width;
        },
    triangle:
        function(length, width){
            return 0.5 * (length * width);
        },
    circle:
        function(radius){
            return 3.14 * (radius * radius);
        }
}
