function resultToAlert(functionName, input) {

    alert(functionName(input));
}

function lastDigitName(number) {

    var digitName = "";

    var digit = parseInt(number.charAt(number.length - 1));

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

    return digitName;

}

function reverseNumber(number) {

    var result = parseInt(number.split('').reverse().join(''));

    return result;

}

function numberOfDivs() {

    var divs = document.getElementsByTagName('div');

    return divs.length;
}

function testFindWordOccurrences() {

    var text = document.getElementById('input3_text').textContent;
    var word = document.getElementById('input3').value;

    /*  for (var i in document.getElementById('input3_case_sensetive')) {
        console.log(i);
    } */

    if (document.getElementById('input3_case_sensetive').checked) {
        return findWordOccurrences(text, word, true);
    }

    return findWordOccurrences(text, word);




}

function findWordOccurrences(text, word, caseSensitive) {

    var matcher = new RegExp('\\b' + word + '\\b', caseSensitive ? 'g' : 'gi');

    var result = text.match(matcher);

    return result ? result.length : 0;

}

function testNumberAppearsInArray() {

    var number = parseFloat(document.getElementById('input5').value);
    var arr = document.getElementById('input5Array').value.split(', ');

    for (var i in arr) {
        arr[i] = parseFloat(arr[i]);
    }


    return numberAppearsInArray(arr, number);


}

function numberAppearsInArray(arr, number) {

    var counter = 0;

    for (var i in arr) {

        if (arr[i] === number) {
            counter++;
        }

    }

    return counter;

}

/* 6. Write a function that checks if the element at given 
position in given array of integers is bigger than its 
two neighbors (when such exist). */

function biggerThanNeighbors(arr, position) {

    if (arr[position] > arr[position - 1] && arr[position] > arr[position + 1]) {
        return true;
    }
    return false;
}

function firstBiggerThanNeighbors(arr) {

    if (!(arr instanceof Array)) {
        arr = arr.split(', ');
        for (var i in arr) {
            arr[i] = parseFloat(arr[i]);
        }
    }

    for (var i = 1; i < arr.length; i++) {
        if (biggerThanNeighbors(arr,i)){
            return i;
        }
    }

    return -1;
}