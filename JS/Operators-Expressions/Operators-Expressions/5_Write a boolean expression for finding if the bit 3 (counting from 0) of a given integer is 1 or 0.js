/// <reference path="js-console.js" />
function Check3BitIs1(element) {
    var value = jsConsole.readInteger(element);

    value >>= 3;

    jsConsole.writeLine((value & 1) === 1);

}