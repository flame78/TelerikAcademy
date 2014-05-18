function Solve(params) {

    //var params = [9, 1, 8, 8, 7, 6, 5, 7, 7, 6];
    //var params = [7, 1, 2, -3, 4, 4, 0, 1];
    //var params = [6, 1, 3 - 5, 8, 7, -6];

    var N = parseInt(params[0]);
    var answer = 1;

    for (var i = 2; i <= N; i++) {
        
        if (parseFloat(params[i]) < parseFloat(params[i - 1])) {
            answer++;
        }
    }
    return answer;
}
