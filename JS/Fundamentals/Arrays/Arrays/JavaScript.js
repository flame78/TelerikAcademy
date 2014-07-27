function arrayMultiplyBy5() {
    var array = new Array(20);

    for (var index = 0; index < array.length; index++) {
        array[index] = index * 5;
        console.log(array[index]);
    }

    console.log('------------------------\n' + array.toString());
}

function compareTwoCharArrays() {
    var arr1 = "lexicographically".split(''); // create "char" array from string
    var arr2 = "multiplied".split('');

    var length = arr1.length > arr2.length ? arr2.length : arr1.length; // get smalest length

    for (var i = 0; i < length; i++) {

        if (arr1[i] > arr2[i]) {
            console.log(arr1[i] + ' > ' + arr2[i]);
        } else if (arr1[i] < arr2[i]) {
            console.log(arr1[i] + ' < ' + arr2[i]);
        } else {
            console.log(arr1[i] + ' = ' + arr2[i]);
        }
    }
}

function maximalSequence() {

    var arr = prompt('Enter array : ', '2, 1, 1, 2, 3, 3, 2, 2, 2, 1').split(', ');

    var number = arr[0];
    var maxRepeat = 1;
    var maxRepeatNumber = number;
    var repeat = 1;
    var result = [];

    for (var i = 1; i < arr.length; i++) {
        if (number === arr[i]) {
            repeat++;
            if (repeat > maxRepeat) {
                maxRepeat = repeat;
                maxRepeatNumber = number;
            }

        } else {
            repeat = 1;
            number = arr[i];
        }
    }

    for (var i = 0; i < maxRepeat; i++) {
        result[i] = maxRepeatNumber;
    }
    alert(result.join(', '));
}

function maximalIncreasingSequence() {

    var maxSequenceLength = 1;
    var maxIncStart = 0;
    var incStart = 0;
    var sequenceLength = 1;
    var output = [];

    var arr = prompt('Enter array : ', '3, 2, 3, 4, 2, 2, 4').split(', ');

    for (var i in arr) {
        arr[i] = parseFloat(arr[i]);
    }

    for (var i = 1; i < arr.length; i++) {
        if (arr[i - 1] < arr[i]) {
            sequenceLength++;
            if (sequenceLength > maxSequenceLength) {
                maxIncStart = incStart;
                maxSequenceLength = sequenceLength;
            }
        } else {
            incStart = i;
            sequenceLength = 1;
        }
    }

    for (var i = maxIncStart; i < maxIncStart + maxSequenceLength; i++) {
        output.push(arr[i]);
    }

    alert(output.join(', '));
}

function selectionSort() {

    var input = prompt('Enter array : ', '3, 2, 3, 4, 2, 2, 4').split(', ');

    var tmp = 0;
    var min;
    var minPosition;
    var arr = [];
    var arr2 = [];
    var result = [];

    for (var i in input) {
        arr[i] = parseFloat(input[i]);
        arr2[i] = arr[i];
    }

    for (var currentIndex in arr) {

        min = arr[currentIndex];
        minPosition = currentIndex;

        for (var index = currentIndex; index < arr.length; index++) {

            if (arr[index] < min) {

                min = arr[index];
                minPosition = index;
            }
        }
        tmp = arr[currentIndex];
        arr[currentIndex] = arr[minPosition];
        arr[minPosition] = tmp;
    }

    alert(arr.join(', '));

    // with second array

    while (arr2.length > 0) {

        min = arr2[0];
        minPosition = 0;

        for (var index = 0; index < arr2.length; index++) {

            if (arr2[index] < min) {

                min = arr2[index];
                minPosition = index;
            }
        }
        result.push(arr2.splice(minPosition, 1));
    }
    alert(result.join(', '));
}

function mostFrequentNumber() {

    var arr = prompt('Enter array : ', '4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3').split(', ');

    var maxRepeat = 1;
    var mRnumber;
    var number;
    var repeat;

    while (arr.length > 0) {

        number = arr[0];
        repeat = 0;

        for (var i = 0; i < arr.length; i++) {

            if (arr[i] === number) {
                repeat++;
                arr.splice(i, 1);
                i--;
            }
        }

        if (repeat > maxRepeat) {
            mRnumber = number;
            maxRepeat = repeat;
        }
    }
    alert(mRnumber + '( ' + maxRepeat + ' times )');
}

function binarySearch() {

    var arr = prompt('Enter array : ', '4, 8, 3, 5, 7, 1, 0, 9, 2, 6').split(', ');

    var element = parseFloat(prompt('Find element :','7'));

    for (var i in arr) {
        arr[i] = parseFloat(arr[i]);
    }

    arr.sort(function (a, b) { return a - b; });

    console.log(arr.toString());

    var startOfSubArray = 0;
    var endOfSubArra = arr.length - 1;
    var middleOfSubArray;

    while (true) {

        if (endOfSubArra - startOfSubArray <0) {
            middleOfSubArray = undefined;
            break;
        }

        middleOfSubArray = ((startOfSubArray + endOfSubArra) / 2) | 0;

        if (arr[middleOfSubArray] === element) {
            break;
        } else if (arr[middleOfSubArray] < element) {
            startOfSubArray = middleOfSubArray+1;
        } else {
            endOfSubArra = middleOfSubArray-1;
        }
    }

    alert('In sorted Array (' + arr.join(', ') + ')\nElement = ' + element + ' is on position ' + middleOfSubArray);
}