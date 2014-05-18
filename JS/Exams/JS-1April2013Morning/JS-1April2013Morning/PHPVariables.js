function Solve(input) {

    if (typeof (input) == 'string') {
        input = input.split('\n');
    }

    var variables = {};
    var output = [];
    var inMultilineComment = false;


    for (var i = 0; i < input.length; i++) {
        //        console.log(input[i]);
        inMultilineComment = processLine(input[i], variables, inMultilineComment);
    }

    for (var i in variables) {
        output.push(i);
    }
    if (output.length == 0) return 0;

    var length = output.length;
    output = length + '\n' + output.sort().join('\n');
    return ( output);

    function processLine(line, variables, inMultilineComment) {

        var inString = '';

        for (var i = 0; i < line.length; i++) {

            if (inMultilineComment) {
                if (line[i] == '*' && line[i + 1] == '/') {
                    inMultilineComment = false;
                    i++;
                }
                continue;
            }

            // String
            if (line[i] == '"') {
                if (inString == '') {
                    inString = '"';
                }
                else if (inString == '"') {
                    inString = '';
                }
                continue;
            } else if (line[i] == "'") {
                if (inString == '') {
                    inString = "'";
                }
                else if (inString == "'") {
                    inString = '';
                }
                continue;
            }

            //escaping in string
            if (inString != '') {
                if (line[i] == '\\') {
                    i += 1;
                    continue;
                }
            }

            // start multiline comment
            if (line[i] == '/' && line[i + 1] == '*' ) {
                inMultilineComment = true;
                i++;
                continue;
            }

            //Single Line Comment
            if (((line[i] == '/' && line[i + 1] == '/') || line[i] == '#') ) {
                break;
            }

            //start variable
            if (line[i] == '$') {
                i++;
                var currentVariable = '';
                while (true) {

                    if ((line[i] >= 'a' && line[i] <= 'z') ||
                        (line[i] >= 'A' && line[i] <= 'Z') ||
                        (line[i] >= '0' && line[i] <= '9') ||
                        line[i] == '_') {

                        currentVariable += line[i];
                        i++;
                    }
                    else {
                        if (currentVariable != '') {
                            variables[currentVariable] = true;
                        }
                        i--;
                        break;
                    }
                }
            }
        }
        return inMultilineComment;
    }
}

/*
var test1 = ['<?php',
"  $browser = $_SERVER['HTTP_USER_AGENT']   ;",
'  $arr =    array();',
'  $arr[$zero]    = $browser;',
'  var_dump($arr);',
'?>'
];

var test2 = ['<?php',
    '/* This is $var1 in  #$comments ',
'$var3 = "Some string \\$var4 with var escaped.";',
'echo $var5; echo("$foo,\'\\"//\\\\$f0_AZ123456789[$asd");',
'// Another comment with variable $var2',
'?>'
];

var test3 = ['<?php',
'   # this is a lonely comment line',
'/* ',
'   $this_is_not_a_variable',
'   "And this is not a string"',
'',
'   $just = \'"code"...{$valid_var}\'; // This is an one-line comment',
'$another = "/* This is not a comment... ";',
'$Inception = "// ... neither \\"this\\", but this is a \'variable\':$var";',
'$arr[$arrid]', 
'?>'
]

var test4 = [];

console.log(Solve(test2));
debugger; */