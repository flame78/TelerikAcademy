/*
1. Assign all the possible JavaScript literals to different variables. 
2. Create a string variable with quoted text in it. For example: 'How you doin'?', Joey said. 
3. Try typeof on all variables you created.
4. Create null, undefined variables and try typeof on them. 
*/

debugger;

var variables = {
    int: 0xff,
    float: 3.3,
    string: "'How you doin'?', Joey said.",
    object: {},
    _array: [1, 2, 3, 4, {}, "asd"],
    $undefined: undefined,
    $null: null,
    $NaN: NaN,
    $Infinity: Infinity,
    $true: true,
    $false: false
};

for (var property in variables) {

    var str = '';

    if (property == '_array') {


        for (var propertyOfArr in variables._array) {

            str += "     variables._array[" + propertyOfArr + ']=' + variables._array[propertyOfArr] + '   // typeof : ' + typeof (variables._array[propertyOfArr]) + "\n";
        }
    }

    if (!confirm(property + '=' + variables[property] + '   // typeof : ' + typeof (variables[property]) + "\n" + str)) {
        break;
    }
}

