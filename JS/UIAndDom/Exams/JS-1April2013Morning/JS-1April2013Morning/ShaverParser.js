function Solve(args) {
  /*  var args = ['2',
        'title:Telerik Academy',
        'subtitle:Free Software Trainings',
        '6',
        '<div>',
        '    <span>@title</span>',
        '    <span>',
        '        @subtitle',
        '    </span>',
        '</div>'];*/

    var numberOfKeys = parseInt(args[0]);
    var keys = {};
    var inVariable = false;
    var result = '';
    var currentVariable = '';


    for (var i = 1; i <= numberOfKeys ; i++) {
        var inp = args[i].split(':');
        keys[inp[0]] = inp[1];
    }

    for (var i = numberOfKeys + 2; i < args.length; i++) {

        var currentLine = args[i];

        

        for (var s = 0; s < currentLine.length; s++) {

            var currentSymbol = currentLine[s];

            if (inVariable) {
                if (currentSymbol == ' ' ||  currentSymbol == '<') {
                    result += keys[currentVariable];
                    inVariable=false;
                    s--;
                    currentVariable = '';
                    continue;
                }
                currentVariable += currentSymbol;
                continue;
            }

            if (currentSymbol == '@' ){
                if (currentLine[s + 1] != '@') {
                    inVariable = true;
                    continue;
                }
                else {
                    result += currentSymbol;
                    s++;
                    continue;
                }
            }

            result += currentSymbol;

        }

        if (inVariable) {
            result += keys[currentVariable];
            currentVariable = '';
            inVariable = false;
        }

        result += '\n';
    }

//    console.log(result.trim());
//    debugger;
    return result;
}


function solve1(params) {

    var s = parseInt(params[0]);
    var result = '';
    var keys = {};
    var sections = {};
    var pl=''


    for (var i = 1; i < s + 1; i++) {
        getKey(params[i], keys);
    }

    var linesNumber = parseInt(params[s + 1]);


    for (var i = s + 2; i < params.length; i++) {

        var currentLine = params[i];

        if (currentLine.indexOf('@section') === 0) {

            var lineSec = [];

            while (true) {

                lineSec.push(params[i]);
                i++;
                if (params[i].indexOf('}') === 0) {
                    getSection(lineSec, sections);
                    break;
                }

            }
            continue;
        }

        

        // Section definnig end
        if (true) {

            var iok = currentLine.indexOf('@');
            if (iok >= 0) {
                if (currentLine[iok + 1] !== '@') {
                    var curVar = ''
                    var j = iok;
                    j++;
                    while (true) {
                        if (currentLine[j] != ' ' && currentLine[j] != '<' && currentLine[j] != '(') {
                            curVar += currentLine[j];
                        }
                        else {

                            if (curVar == 'renderSection') {

                                curVar = params[i].substring(iok + 3 + curVar.length).split('"')[0];
                                for (var s in sections[curVar]) {
                                    result += params[i].substring(0, iok) + sections[curVar][s] + '\n'
                                }
                                break;
                            } else if (curVar == 'if') {
                                curVar = params[i].substring(iok + 3 + curVar.length).split(')')[0];
                                debugger;
                                if (keys[curVar]) {
                                    params.splice(i, 1)
                                    var k = i;
                                    while (params[k].indexOf('}') >= 0) {
                                        k++;
                                    }
                                    params.splice(k, 1);
                                    i--;
                                    continue;
                                } else {

                                    while (params[i].indexOf('}') >= 0) {
                                        i++;
                                    }
                                    continue;
                                }

                            }
                                // here change @key
                            else {
                                params[i] = params[i].substring(0, iok) + keys[curVar] + params[i].substring(iok + 1 + curVar.length);
                                break;
                            }
                        }
                        j++;
                    }
                    continue;
                }
                else {
                    result += params[i].substring(0, iok) + params[i].substring(iok + 1) + '\n';
                    continue;
                }

            }

            result += currentLine + '\n';


        }

    }


    return result;


    //-------------------------------------------
    function getKey(line, keys) {
        var arr = line.split(':');
        keys[arr[0]] = arr[1];
    }

    function getSection(lineSec, sections) {

        var secN = lineSec[0].split(' ')[1];
        sections[secN] = [];
        for (var i = 1; i < lineSec.length; i++) {

            sections[secN].push(lineSec[i]);
        }
    }
}