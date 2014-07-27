function Div5and7(element) {

    var value = jsConsole.readInteger(element);
   

    if (value % 5 === 0) {
        if (value % 7 === 0) {
            jsConsole.writeLine("True");
            return;
        }
    }

    jsConsole.writeLine("False");

}
