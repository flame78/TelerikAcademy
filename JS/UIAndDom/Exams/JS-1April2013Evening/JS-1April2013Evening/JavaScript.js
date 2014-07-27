function SolveProblem1(params) {
    var N = parseInt(params[0]);
    var answer = 0;

    var maxSum = -Infinity;

    for (var startIndex = 1; startIndex < params.length; startIndex++) {

        var sum = 0;

        for (var i = startIndex; i < params.length; i++) {
            sum += parseFloat(params[i]);

            if (sum > maxSum) {
                maxSum = sum;
            }
        }
    }

    answer = maxSum;
    alert(answer);
    return answer;
}

function Solve(args) {

    var numbers = args[0].split(' ');

    var M = parseInt(numbers[1]);
    var N = parseInt(numbers[0]);

    numbers = args[1].split(' ');

    var posX = parseInt(numbers[1]);
    var posY = parseInt(numbers[0]);

    var sum = 0;
    var cells = 0;
    var command = '';

    for (var i = 2; i < N + 2; i++) {
        args[i] = args[i].split('');
    }

    while (true) {

        if (posX < 0 || posY < 0 || posX >= M || posY >= N) {
            return ('out ' + sum);
        }

        command = args[posY + 2][posX];
        args[posY + 2][posX] = 'v';

        if (command == 'v') {
            return ('lost ' + cells);
        }

        sum += posY * (M) + posX + 1;
        cells++;

        if (command == 'l') {
            posX--;
        } else if (command == 'r') {
            posX++;

        } else if (command == 'u') {
            posY--;

        } else if (command == 'd') {
            posY++;
        }
    }
}