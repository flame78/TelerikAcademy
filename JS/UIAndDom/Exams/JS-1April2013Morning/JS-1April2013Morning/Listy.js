function Solve(input) {
    var variables = {};
    var params;
    var result;

    if (typeof (input) == 'string') {
        input = input.split('\n');
    }

    for (var i = 0; i < input.length; i++) {
        params = getParameters(input[i]);
        result = execute(params, variables);
    }

    return result.toString();

    function execute(inp, variables) {
        
        if (inp[0] == 'def') {
            var curVar = inp[1];
            variables[curVar] = calc(inp.splice(2, inp.length - 2), variables);
            return variables[curVar];
        }
        else {
            return calc(inp, variables);
        }

    }

    function calc(inp, variables) {
        
        for (var i = 0; i < inp.length; i++) {
            if (inp[i]=='sum' || 
                inp[i]=='avg' ||
                inp[i]=='min' ||
                inp[i]=='max' ||
                inp[i]=='[' ||
                inp[i] == ']') {
                continue;
            }
            if (isNaN(inp[i])) {
                if (isNaN(variables[inp[i]])){
                    var curVar=inp[i];
                    inp.splice(i,1);
                    for (var j = 0; j < variables[curVar].length; j++) {
                        inp.splice(i,0,variables[curVar][j]);
                        i++;
                    }
                    i--;
                }
                else {
                    inp[i]=parseInt(variables[inp[i]]);
                    continue;
                }
            }
            else {
                inp[i] = parseInt(inp[i]);
                continue;
            }

        }
        switch (inp[0]) {
            case '[':
                inp.splice(inp.length - 1, 1);
                inp.splice(0, 1);
                return inp;
            case 'sum':
                var sum = inp[2];
                for (var i = 3; i < inp.length - 1; i++) {
                    sum += inp[i];
                }
                return sum;
            case 'min':
                var min = +Infinity;
                for (var i = 2; i < inp.length - 1; i++) {
                    if (min > inp[i]) min = inp[i];
                }
                return min;
            case 'max':
                var max = -Infinity;
                for (var i = 2; i < inp.length - 1; i++) {
                    if (max < inp[i]) max = inp[i];
                }
                return max;
            case 'avg':
                var sum = inp[2];
                for (var i = 3; i < inp.length - 1; i++) {
                    sum += inp[i];
                }
                return (sum/(inp.length-3))|0;
            default:

        }
    }

    function getParameters(line) {
        line = line.trim();
        line=line.split('');

        for (var i = 0; i < line.length; i++) {

            if (line[i] == ' ') {
                line[i] = ',';
                continue;
            }

            if (line[i] == '[' || line[i] == ']') {
                line.splice(i + 1, 0, ',');
                line.splice(i, 0, ',');
                i++;
                continue;
            }
        }
        line = line.join('');
        line = line.split(',');

        for (var i = 0; i < line.length; i++) {
            if (line[i] == '') {
                line.splice(i, 1);
                i--;
            }
        }
        return line;
    }
  /*  function processLine(line, variables) {

        var inDef = false;
        var inList = false;
        var currentVar = '';
        var currentSymbol;
        var current4Symb;
        var inSum = false;
        var inMax = false;
        var inAvg = false;
        var currentNumber = '';
        var sum = [];


        for (var i = 0; i < line.length; i++) {

            currentSymbol = line[i];
            current4Symb = line.substr(i, 4);

            if (inSum) {
                if (currentSymbol=']') {

                }
            }
            //read def var
            if (inDef) {
                if (currentSymbol == ' ' || currentSymbol == '[') {
                    if (currentVar == '') {
                        continue;
                    }
                    else {
                        variables[currentVar] = true;
                        inDef = false;
                        i--;
                        debugger;
                        continue;
                    }
                }
                else {
                    currentVar += currentSymbol;
                    continue;
                }
            }

            if (current4Symb == 'def ') {
                inDef = true;
                i += 3;
            }

            if (current4Symb == 'sum ' || current4Symb == 'sum[') {
                inDef = true;
                i += 3;
            }



        }
    }

    function sum(inp) {
        return result;
    } */
}