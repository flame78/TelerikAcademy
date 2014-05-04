/// <reference path="js-console.js" />

function Check3DigIs7(element) {

    var value = jsConsole.readInteger(element);

    value /= 100;
    value = Math.floor(value);
    value -= 7;

    jsConsole.writeLine(value%10===0);
}
