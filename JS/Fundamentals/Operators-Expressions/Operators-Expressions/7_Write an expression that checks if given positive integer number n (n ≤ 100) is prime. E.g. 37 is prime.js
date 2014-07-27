/// <reference path="js-console.js" />
function IsPrime(element) {
    var value = jsConsole.readFloat(element);

    for (var i = 2; i <= Math.sqrt(value) ; i++) {
        if (value % i === 0) {
            jsConsole.writeLine("False");
            return;
        }

    }

    jsConsole.writeLine("True");
}