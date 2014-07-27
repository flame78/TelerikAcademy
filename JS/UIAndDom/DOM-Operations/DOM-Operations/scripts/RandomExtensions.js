function randomColor() {
    return 'rgba(' + randomNumber(0, 255) + ',' + randomNumber(0, 255) + ',' + randomNumber(0, 255) + ','+ randomNumber()/100 + ')';
}

function randomNumber(start, end) {

    if (start === undefined) {
        start = 100;
    }

    if (end === undefined) {
        end = start;
        start = 0;
    }

    end += 1;
    return 0 | Math.random() * (end - start) + start;
}