function sort2Int() {
    //  1. Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one. 

    var firstInt = parseInt(prompt('Enter first integer', ''));
    var secondInt = parseInt(prompt('Enter second integer', ''));

    debugger;

    if (firstInt > secondInt) {
        var tmp = secondInt;
        secondInt = firstInt;
        firstInt = tmp;
    }

    var output = 'After sort.\nFirst integer = ';
    output += firstInt;
    output += '\nSecond integer = ';
    output += secondInt;
    alert(output);


}

function showSign() {
    // 2.Write a script that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.
    var firstValue = parseFloat(prompt('Enter first real number', ''));
    var secondValue = parseFloat(prompt('Enter second real number', ''));
    var thirdValue = parseFloat(prompt('Enter third real number', ''));

    debuger;

    var negativeValues = 0;

    if (firstValue < 0) {
        negativeValues++;
    }
    if (secondValue < 0) {
        negativeValues++;
    }
    if (thirdValue < 0) {
        negativeValues++;
    }

    if (firstValue === 0 || secondValue === 0 || thirdValue === 0) {
        negativeValues = 0;
    }

    if (negativeValues % 2 === 0) {
        alert('sign of the product three real numbers is +')
    }
    else { alert('sign of the product three real numbers is -') }
}

function findBiggest() {
    // 3.Write a script that finds the biggest of three integers using nested if statements.

    var firstValue = parseInt(prompt('Enter first integer', ''));
    var secondValue = parseInt(prompt('Enter second integer', ''));
    var thirdValue = parseInt(prompt('Enter third real integer', ''));

    var biggerValue = firstValue;

    if (secondValue > biggerValue) {
        biggerValue = secondValue;
        if (thirdValue > biggerValue) {
            biggerValue = thirdValue;
        }
    }
    else if (thirdValue > biggerValue) {
        biggerValue = thirdValue;
    }

    alert('Biggest is : ' + biggerValue);
}

function sort3Numbers() {
    //4. Sort 3 real values in descending order using nested if statements.

    var firstValue = parseFloat(prompt('Enter first real number', ''));
    var secondValue = parseFloat(prompt('Enter second real number', ''));
    var thirdValue = parseFloat(prompt('Enter third real number', ''));

    var tmp = 0;

    debugger;

    if (firstValue >= secondValue && firstValue >= thirdValue) {
        if (secondValue < thirdValue) {
            tmp = secondValue;
            secondValue = thirdValue;
            thirdValue = tmp;
        }
    }
    else if (secondValue >= firstValue && secondValue >= thirdValue) {
        tmp = firstValue;
        firstValue = secondValue;
        secondValue = tmp;
        if (secondValue < thirdValue) {
            tmp = secondValue;
            secondValue = thirdValue;
            thirdValue = tmp;
        }
    }
    else if (thirdValue >= secondValue && thirdValue >= firstValue) {
        tmp = firstValue;
        firstValue = thirdValue;
        thirdValue = tmp;
        if (secondValue < thirdValue) {
            tmp = secondValue;
            secondValue = thirdValue;
            thirdValue = tmp;
        }
    }
    alert('\nSorted in descending order\nfirst number = ' + firstValue + '\nsecond number = ' + secondValue + '\nthird number = ' + thirdValue);
}

function nameOfDigit() {
    //5. Write script that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.

    var digit;
    var digitName;

    debugger;

    while (!(digit >= 0 && digit <= 9)) {
        digit = parseInt(prompt('Enter digit betwen 0....9 : '));

    }

    switch (digit) {
        case 0:
            digitName = 'Zero';
            break;
        case 1:
            digitName = 'One';
            break;
        case 2:
            digitName = 'Two';
            break;
        case 3:
            digitName = 'Three';
            break;
        case 4:
            digitName = 'Four';
            break;
        case 5:
            digitName = 'Five';
            break;
        case 6:
            digitName = 'Six';
            break;
        case 7:
            digitName = 'Seven';
            break;
        case 8:
            digitName = 'Eight';
            break;
        case 9:
            digitName = 'Nine';
            break;
        default:
            break;
    }

    alert(digitName);
}

function rootsOfQuadraticEquations() {
    //6. Write a script that enters the coefficients a, b and c of a quadratic equation a*x^2 + b*x + c = 0 and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.
    var a = parseFloat(prompt('Enter coefficient A of quadratic equation A*x^2 + B*x + C = 0 ', ''));
    var b = parseFloat(prompt('Enter coefficient B of quadratic equation A*x^2 + B*x + C = 0 ', ''));
    var c = parseFloat(prompt('Enter coefficient C of quadratic equation A*x^2 + B*x + C = 0 ', ''));

    debugger;

    var d = b * b - 4 * a * c;

    if (a === 0) {
        alert('1 real roots :' + (-c / b));
    } else if (d < 0) {
        alert('0 real roots');
    } else if (d === 0) {
        alert('1 real roots :' + (-b / 2 * a));
    } else {
        alert('2 real roots :' + ((-b +Math.sqrt(d)) / (2 * a)) +
            '\n                    :' + ((-b -Math.sqrt(d)) / (2 * a)));
    }
}

function maxOf5() {
    //7. Write a script that finds the greatest of given 5 variables.

    var arr = [5];

    debugger;
    
    var max=-Infinity;

    for (var i = 0; i < 5; i++) {
        arr[i]=parseFloat(prompt('Enter real number : '));
        if (max<arr[i]) {
            max=arr[i];
        }
    }

    alert('Greatest of given 5 is : ' + max);
}

function englishPronunciation() {
    /*
     8. Write a script that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	0  'Zero'
	273  'Two hundred seventy three'
	400  'Four hundred'
	501  'Five hundred and one'
	711  'Seven hundred and eleven'
     */


    // my solution from c#1 rewriten for JS

    var number;
    var input;
    var englishPronunciation = "";
    var firstDigit = "", secondDigit = "", last2Digit = "";

    do
    {

        input=prompt("Enter number in the range [0...999]: ");
        number=input*1;
        if (number <= 999 && number >= 0) break;
    } while (true);

    debugger;

    input = input.toString();
    input = Array(3 - input.length + 1).join(' ') + input;
    

    firstDigit = input.substr(0, 1);
    secondDigit = input.substr(1, 1);
    last2Digit = input.substr(1, 2);

    switch (firstDigit)
    {
        case "1":
            englishPronunciation += "One hundred";
            break;
        case "2":
            englishPronunciation += "Two hundred";
            break;
        case "3":
            englishPronunciation += "Three hundred";
            break;
        case "4":
            englishPronunciation += "Four hundred";
            break;
        case "5":
            englishPronunciation += "Five hundred";
            break;
        case "6":
            englishPronunciation += "Six hundred";
            break;
        case "7":
            englishPronunciation += "Seven hundred";
            break;
        case "8":
            englishPronunciation += "Eight hundred";
            break;
        case "9":
            englishPronunciation += "Nine hundred";
            break;

        default:
            break;

    }

    if ((last2Digit|0) > 0 && (last2Digit|0) < 20 && number > 99) englishPronunciation += " and ";
        
    switch (secondDigit)
    {
                
        case "2":
            englishPronunciation += " twenty ";
            last2Digit = input.substr(2, 1);
            break;
        case "3":
            englishPronunciation += " thirty ";
            last2Digit = input.substr(2, 1);
            break;
        case "4":
            englishPronunciation += " forty ";
            last2Digit = input.substr(2, 1);
            break;
        case "5":
            englishPronunciation += " fifty ";
            last2Digit = input.substr(2, 1);
            break;
        case "6":
            englishPronunciation += " sixty ";
            last2Digit = input.substr(2, 1);
            break;
        case "7":
            englishPronunciation += " seventy ";
            last2Digit = input.substr(2, 1);
            break;
        case "8":
            englishPronunciation += " eighty ";
            last2Digit = input.substr(2, 1);
            break;
        case "9":
            englishPronunciation += " ninety ";
            last2Digit = input.substr(2, 1);
            break;

        default:
            break;

    }

      
    switch ((last2Digit|0))
    {
        case 1:
            englishPronunciation += "one";
            break;
        case 2:
            englishPronunciation += "two";
            break;
        case 3:
            englishPronunciation += "three";
            break;
        case 4:
            englishPronunciation += "four";
            break;
        case 5:
            englishPronunciation += "five";
            break;
        case 6:
            englishPronunciation += "six";
            break;
        case 7:
            englishPronunciation += "seven";
            break;
        case 8:
            englishPronunciation += "eight";
            break;
        case 9:
            englishPronunciation += "nine";
            break;
        case 10:
            englishPronunciation += "ten";
            break;
        case 11:
            englishPronunciation += "eleven";
            break;
        case 12:
            englishPronunciation += "twelve";
            break;
        case 13:
            englishPronunciation += "thirteen";
            break;
        case 14:
            englishPronunciation += "fourteen";
            break;
        case 15:
            englishPronunciation += "fifteen";
            break;
        case 16:
            englishPronunciation += "sixteen";
            break;
        case 17:
            englishPronunciation += "seventeen";
            break;
        case 18:
            englishPronunciation += "eighteen";
            break;
        case 19:
            englishPronunciation += "nineteen";
            break;
        default:
            break;

    }

    if (number==0) englishPronunciation += "zero";
    

    englishPronunciation = englishPronunciation.charAt(0).toUpperCase() + englishPronunciation.slice(1);

    alert(englishPronunciation);
}
