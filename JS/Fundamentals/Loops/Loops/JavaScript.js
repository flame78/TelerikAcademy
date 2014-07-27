function numbers() {

    var N = prompt('Enter N : ');
    var arr = [];

    for (var i = 1; i <= N; i++) {
        arr[i - 1] = i;
    }

    alert(arr.join(', '));
}

function numbersNotDivisibleBy3And7() {

    var N = prompt('Enter N : ');
    var arr = [];
    var index = 0;

    for (var i = 1; i <= N; i++) {

        if (!(i % 3 === 0 && i % 7 === 0)) {
            arr[index] = i;
            index++;
        }
    }

    alert(arr.join(', '));
}

function maxAndMinInSequence() {

    var sequence = prompt('Enter sequience (4,2,4.5,3,1,-999 :', '4,2,4.5,3,1,-999');

    var arr = sequence.split(',');

    var max = -Infinity;
    var min = Infinity;

    for (var index in arr) {

        if (arr[index] > max) {
            max = arr[index];
        }

        if (arr[index] < min) {
            min = arr[index];
        }
    }

    alert('Max = ' + max + '\nMin = ' + min);

}

function findSmallestAndLargestPropertyLexicographically() {

    var resultDocument = getSmallestAndLargestProperty(document);
    var resultWindow = getSmallestAndLargestProperty(window);
    var resultNavigator = getSmallestAndLargestProperty(navigator);

    alert('In document\nSmallest  = ' + resultDocument.min + '\nLargest = ' + resultDocument.max +
          '\n\nIn window\nSmallest  = ' + resultWindow.min + '\nLargest = ' + resultWindow.max +
          '\n\nIn navigator\nSmallest  = ' + resultNavigator.min + '\nLargest = ' + resultNavigator.max);
}

function getSmallestAndLargestProperty(element) {

    var first = true;

    var elementMax, elementMin;

    for (var property in element) {

        if (first) {
            elementMax = property;
            elementMin = property;
            first = false;
        }

        if (property < elementMin) {
            elementMin = property;
        }

        if (property > elementMax) {
            elementMax = property;
        }
    }

    return {
        min: elementMin,
        max: elementMax
    };
}