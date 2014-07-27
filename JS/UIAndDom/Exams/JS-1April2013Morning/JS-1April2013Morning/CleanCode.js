var test1 = ['10', 'using System; // no comment...', 'class JustClass', '{ /* Just', 'multiline,comment  */private void JustMethod()', ' {', '     // string str="inception/*//*/";', ' }', '}'];

var test2 = ['10', 'class HardTest',
'    ',
'{',
'    public HardMethod()',
'{',
'        string str = @"//not a ',
'        comment ;)";//(y)',
'     string str2 = "/*no\\"oo\\\\oo*/";/*noo*/',
'     }','\t','\t',
'     }'];

console.log(Solve(test2));

function Solve(args) {

    var inMultilineComment = false,
        inSingleLineComment = false,
        inEmptyLine = true,
        inString = false,
        inSQString = false,
        inMultiString = false,
        inDocumentation = false,
        result = '',
        startOfLine = 0;


    args.splice(0, 1);


    var input = args.join('\n');

    for (var i = 0; i < input.length; i++) {
        var currentSymbol = input[i];

        
        if (inMultilineComment) {
            if (currentSymbol == '*') {
                if (input[i + 1] == '/') {
                    inMultilineComment = false;
                    i++;
                   
                }
            }
            continue;
        }

        if (currentSymbol == '\n') {
            if (inEmptyLine) {
                result = result.substring(0, startOfLine);
            }
            inSingleLineComment = false;
            inEmptyLine = true;
            inDocumentation = false;
            startOfLine = result.length;
        }

        if (inDocumentation) {
            result += currentSymbol;
            continue;
        }

        if (inSingleLineComment) {
            continue;
        }

        if (currentSymbol == '@' && !inSingleLineComment && !inMultilineComment) {
            if (input[i + 1] == '"') {
                inMultiString = true;
                result += currentSymbol;
                i++;
                result += input[i];
                continue;
            }
        }

        if (inMultiString) {
            if (currentSymbol == '"') {
                inMultiString = false;
            }
            result += currentSymbol;
            continue;
        }

        

        if (inString) {
            if (currentSymbol == '\\') {
  //              console.log(input[i + 1]);
                if (input[i + 1] == '"') {
                    result += currentSymbol;
                    i++;
                    result += input[i];
                    continue;
                }
            } else if (currentSymbol == '"') {
                inString = false;
            }
            result += currentSymbol;
            continue;
        }

        if (inSQString) {
            if (currentSymbol == '\\') {
                //              console.log(input[i + 1]);
                if (input[i + 1] == "'") {
                    result += currentSymbol;
                    i++;
                    result += input[i];
                    continue;
                }
            } else if (currentSymbol == "'") {
                inSQString = false;
            }
            result += currentSymbol;
            continue;
        }

        if (currentSymbol == '"' && !inSingleLineComment && !inMultilineComment) {
            inString = true;
            result += currentSymbol;
            continue;
        }

        if (currentSymbol == "'" && !inSingleLineComment && !inMultilineComment) {
            inSQString = true;
            result += currentSymbol;
            continue;
        }

        if (currentSymbol == '/') {
            if (input[i + 1] == '/') {
                if (input[i + 2] == '/') {
                    inDocumentation = true;
                } else {

                    inSingleLineComment = true;
                    i++;
                    continue;
                }
            } else if (input[i + 1] == '*') {
                inMultilineComment = true;
                i++;
                continue;
            }
            
        }


        if (currentSymbol != '\t' && currentSymbol != ' ' && currentSymbol != '\n') {
            inEmptyLine = false;
        }


        result += currentSymbol;

    }

    return result;
}

