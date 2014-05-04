/// <reference path="js-console.js" />

function WithinCircle(x, y) {
    var valX = jsConsole.readFloat(x);
    var valY = jsConsole.readFloat(y);

    jsConsole.writeLine((Math.abs(valX) * Math.abs(valX) + Math.abs(valY) * Math.abs(valY)) <= 5 * 5);
}