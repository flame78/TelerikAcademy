/// <reference path="C:\Users\Ivan\Desktop\github\JS\Canvas\Canvas\canvas-vsdoc.js" />
/// <reference path="C:\Users\Ivan\Desktop\github\JS\Canvas\Canvas\CanvasExtensions.js" />

window.onload = function () {

    var img = new Image();
    img.src = 'Untitled.png';
    var canvas = Canvas.vsGet(document.getElementById('canvas'));
    var ctx = canvas.getContext('2d');
    var grd = ctx.createRadialGradient(100, 50, 0, 200, 50, 500);

    canvas.addEventListener("mousedown", getPosition, false);
    canvas.addEventListener("dblclick", drawOriginal, false);

    grd.addColorStop(0, "#555");
    grd.addColorStop(1, "#111");

    // Fill with gradient
    ctx.fillStyle = grd;
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    ctx.lineWidth = 3;
    ctx.strokeStyle = "#22545F";
    ctx.fillStyle = "#8EC8D5";

    // Head
    ctx.drawEllipse(140, 200, 70, 65, 1, 1);

    // Left Eye
    ctx.drawEllipse(100, 180, 10, 7, 1);
    ctx.fillStyle = "#22545F";
    ctx.drawEllipse(98, 180, 3, 5, 1, 1);

    // Right Eye
    ctx.drawEllipse(160, 180, 10, 7, 1);
    ctx.drawEllipse(158, 180, 3, 5, 1, 1);

    // Mouth
    ctx.drawEllipse(125, 235, 25, 10, 1, 0, 10);

    // Nose
    ctx.beginPath();
    ctx.moveTo(125, 180);
    ctx.lineTo(110, 210);
    ctx.lineTo(125, 210);
    ctx.stroke();

    // Hat
    ctx.strokeStyle = "#262626";
    ctx.fillStyle = "#396693";

    ctx.drawEllipse(140, 145, 80, 15, 1, 1);
    ctx.drawEllipse(145, 130, 40, 15, 1, 1);
    ctx.fillRect(105, 55, 80, 75);
    ctx.beginPath();
    ctx.moveTo(105, 55);
    ctx.lineTo(105, 130);
    ctx.stroke();
    ctx.beginPath();
    ctx.moveTo(185, 55);
    ctx.lineTo(185, 130);
    ctx.stroke();
    ctx.drawEllipse(145, 55, 40, 15, 1, 1);

    // bike

    ctx.strokeStyle = "#337D8F";
    ctx.fillStyle = "#8EC8D5";
    ctx.drawCircle(75, 425, 60, 1, 1);
    ctx.drawCircle(300, 425, 60, 1, 1);
    ctx.drawCircle(180, 420, 15, 1);

    ctx.beginPath();
    ctx.moveTo(310, 270);
    ctx.lineTo(280, 305);
    ctx.lineTo(235, 320);
    ctx.moveTo(280, 305);
    ctx.lineTo(300, 420);
    ctx.moveTo(286, 347);
    ctx.lineTo(180, 420);
    ctx.lineTo(77, 420);
    ctx.lineTo(145, 347);
    ctx.closePath();
    ctx.moveTo(180, 420);
    ctx.lineTo(130, 310);
    ctx.moveTo(110, 310);
    ctx.lineTo(150, 310);
    ctx.moveTo(190, 430);
    ctx.lineTo(200, 440);
    ctx.moveTo(169, 409);
    ctx.lineTo(159, 399);
    ctx.stroke();

    drawHouse(500, 160);

    function drawHouse(x, y) {
        ctx.fillStyle = "#975b5b";
        ctx.strokeStyle = "black";
        ctx.beginPath();
        ctx.fillRect(x, y, 286, 215);
        ctx.strokeRect(x, y, 286, 215);
        ctx.moveTo(x, y);
        ctx.lineTo(x + 143, y - 143);
        ctx.lineTo(x + 143 * 2, y);
        ctx.stroke();
        ctx.fill();
        drawChimney(x + 200, y - 110);
        drawDoor(x + 71, y + 215);
        drawWindow(x + 20, y + 25);
        drawWindow(x + 160, y + 25);
        drawWindow(x + 160, y + 118);
    }

    function drawChimney(x, y) {
        ctx.beginPath();
        ctx.drawEllipse(x + 15, y, 15, 5, 1, 1);
        ctx.stroke();
        ctx.moveTo(x, y);
        ctx.lineTo(x, y + 80);
        ctx.moveTo(x + 30, y);
        ctx.lineTo(x + 30, y + 80);
        ctx.fillRect(x, y, 30, 70);
        ctx.fill();
        ctx.stroke();
    }

    function drawWindow(x, y) {
        ctx.fillStyle = "black";
        ctx.beginPath();
        ctx.fillRect(x, y, 50, 32);
        ctx.fillRect(x + 53, y, 50, 32);
        ctx.fillRect(x + 53, y + 35, 50, 32);
        ctx.fillRect(x, y + 35, 50, 32);
    }

    function drawDoor(x, y) {
        ctx.drawEllipse(x, y - 85, 40, 19, 1);
        ctx.fillRect(x - 40, y - 85, 80, 80);
        ctx.beginPath();
        ctx.moveTo(x, y);
        ctx.lineTo(x, y - 103);
        ctx.moveTo(x - 40, y);
        ctx.lineTo(x - 40, y - 85);
        ctx.moveTo(x + 40, y);
        ctx.lineTo(x + 40, y - 85);
        ctx.stroke();
        ctx.drawCircle(x - 10, y - 30, 5);
        ctx.stroke();
        ctx.drawCircle(x + 10, y - 30, 5);
        ctx.stroke();
    }


    function drawOriginal() {
        ctx.drawImage(img, 0, 0);
    }


    function getPosition(event) {
        var x = event.x;
        var y = event.y;

        x -= canvas.offsetLeft;
        y -= canvas.offsetTop;

        console.log(x + ", " + y);
    }

}



