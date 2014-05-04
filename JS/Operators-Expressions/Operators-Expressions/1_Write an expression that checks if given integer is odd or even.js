
function OddOrEven(element) {

    var value = jsConsole.readInteger(element);
    var result = (value % 2 === 0) ? "Even" : "Odd";

    jsConsole.writeLine("Number " + value + " is " + result);

    // Това не работи не мога да разбера защо !?!?

    jsConsole.writeLine("Number " + value + " is " + value % 2 == 0 ? "Even" : "Odd");
    
}
