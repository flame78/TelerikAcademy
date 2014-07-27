var drawer = function drawer(canvasID) {

    var container = document.getElementById(canvasID);
    var ctx = container.getContext("2d");

    function rect(x, y, width, height) {
        ctx.beginPath();
        ctx.rect(x, y, width, height);
        ctx.fill();
    }    function circle(centerX, centerY, radius) {
        ctx.beginPath();
        ctx.arc(centerX, centerY, radius, 0, 2 * Math.PI);
        ctx.fill();
    }

    function line(fromX, fromY, toX, toY) {
        ctx.beginPath();
        ctx.lineWidth = 5
        ctx.moveTo(fromX, fromY);
        ctx.lineTo(toX, toY);
        ctx.stroke();
    }

    return {
        rect: rect,
        circle: circle,
        line: line
    }
};
