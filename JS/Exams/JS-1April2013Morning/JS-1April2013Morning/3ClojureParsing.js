function Solve(args) {

  //  var args = ['(def     lube    5)', '(def     Lube    6)', '(def pe6o (+ lube Lube ))', '(def joro pe6o)', '(           *        pe6o        joro     )'];
    //    var args = ['(def myFunc 5)','(def myNewFunc (+  myFunc  myFunc 2))','(def MyFunc (* 2  myNewFunc))','(/   MyFunc  myFunc)'];
    // var args = ['(+ 1 2)'];
    // var args = ['(def func 10)', '(def newFunc (+  func 2))', '(def sumFunc (+ func func newFunc 0 0 0))', '(* sumFunc 2)'];

    var func = {},
        tmp = [],
        answer;

    for (var i = 0; i < args.length; i++) {

        tmp = args[i].split(' ');

        for (var j = 0; j < tmp.length; j++) {

            if (tmp[j] === '') {
                tmp.splice(j, 1);
                j--;
            }

            if (tmp[j] === '(') {
                tmp[j] = '(' + tmp[j + 1];
                tmp.splice(j + 1, 1);
                j--;
            }

            if (tmp[j] === ')') {
                tmp[j - 1] = tmp[j - 1] + ')';
                tmp.splice(j, 1);
                j--;
            }

            if (tmp[j] === '))') {
                tmp[j - 1] = tmp[j - 1] + '))';
                tmp.splice(j, 1);
                j--;
            }

        }

        args[i] = tmp.join(' ');
    }


    function calt(data, input) {
        if (input[0] === '(' || input[0] === ' ') {
            input = input.substring(1, input.length - 1);
        }

        if (input[0] === '( ') {
            input = input.substring(2, input.length - 2);
        }

        var result = 0,
            arr = input.split(' ');



        for (var i = 0; i < arr.length; i++) {

            if (arr[i] !== '+' && arr[i] !== '-' && arr[i] !== '*' && arr[i] !== '/') {

                if (isNaN(arr[i])) { arr[i] = data[arr[i]]; }

                arr[i] = parseFloat(arr[i]);
            }

        }


        switch (arr[0]) {
            case '+':
                result = arr[1];
                for (var i = 2; i < arr.length; i++) {
                    result += arr[i];
                }
                return result;
                break;
            case '-':
                result = arr[1];
                for (var i = 2; i < arr.length; i++) {
                    result -= arr[i];
                }
                return result;
                break;
            case '*':
                result = arr[1];
                for (var i = 2; i < arr.length; i++) {
                    result *= arr[i];
                }
                return result;
                break;
            case '/':
                result = arr[1];
                for (var i = 2; i < arr.length; i++) {
                    if (arr[i] === 0) { return null; }
                    result /= arr[i];
                }
                return result | 0;
                break;
            default:
                return arr[0];

        }
    }

    for (var i = 0; i < args.length; i++) {

        args[i] = args[i].substring(1, args[i].length - 1);
        // console.log(args[i]);
        if (args[i].substr(0, 4) === 'def ') {
            tmp = args[i].split(' ');
            func[tmp[1]] = calt(func, args[i].substring(5 + tmp[1].length, args[i].length));
            if (func[tmp[1]] === null) { return 'Division by zero! At Line:' + (i + 1); }
        }


        if (i === args.length - 1) { return calt(func, args[i]); }

    }
} 

