function Solve(params) {

    //var params = [9, 1, 8, 8, 7, 6, 5, 7, 7, 6];
    //var params = [7, 1, 2, -3, 4, 4, 0, 1];
   // var params = ['6 7 3','0 0','2 2','-2 2','3 -1'];
    
    var lineArr = params[0].split(' ');

    var yN = parseInt(lineArr[0]);
    var xM = parseInt(lineArr[1]);
    var J = parseInt(lineArr[2]);

    lineArr = params[1].split(' ');

    var x = parseInt(lineArr[1]);
    var y = parseInt(lineArr[1]);

    var answer = 1;

    var matrix = [];

    for (var i = 0; i < xM; i++) {
        matrix[i] = [];
    }

    var sum = 0;
    var jumps = 0;
    
    for (var i = 0; i < J ; i++) {

        if (matrix[x][y]) {
            return 'caught ' + jumps;
        }

        matrix[x][y] = true;
        jumps++;
        sum += y * xM + x + 1;

        lineArr = params[i + 2].split(' ');
        y += parseInt(lineArr[0]);
        x += parseInt(lineArr[1]);

        if (x >= xM || y >= yN || x < 0 || y < 0) {
            return 'escaped ' + sum;
        }

        if (i === J - 1) { i = -1;}
    }
}
