/// <reference path="C:\Users\Ivan\Desktop\github\JS\Canvas\Canvas\canvas-vsdoc.js" />
/// <reference path="C:\Users\Ivan\Desktop\github\JS\Canvas\Canvas\Picture.js" />

function flyingBall() {

    var BALL_RADIUS = 10;
    var MOVE_SPEED = 1;

    var canvas = Canvas.vsGet(document.getElementsByTagName('canvas')[0]);
    var ctx = canvas.getContext('2d');

    ctx.clearRect(0, 0, canvas.width, canvas.height);

    var balls = makeBalls();

    animate();

    function animate() {

        //ctx.clearRect(0,0, canvas.width, canvas.height);

        window.onload();

        ctx.strokeStyle = '#00F';
        ctx.fillStyle = '#F00';
        ctx.lineWidth = 2;

        for (var i in balls) {

            ball = balls[i];

            letsMove(ball);
            ctx.drawCircle(ball.x, ball.y, BALL_RADIUS, 1, 1)
        }


        requestAnimationFrame(function () {
            animate();
        });
    }

    function letsMove(ball) {

        ball.oldX = ball.x;
        ball.oldY = ball.y;

        if (ball.x <= BALL_RADIUS || (canvas.width - BALL_RADIUS) <= ball.x) {
            ball.speedX *= -1;
        }

        if (ball.y <= BALL_RADIUS || (canvas.height - BALL_RADIUS) <= ball.y) {
            ball.speedY *= -1;
        }

        ball.x += ball.speedX;
        ball.y += ball.speedY;
    }

    function makeBalls() {

        var balls = [];

        balls.push({
            x: 210,
            y: 210,
            oldX: this.x,
            oldY: this.y,
            speedX: MOVE_SPEED,
            speedY: MOVE_SPEED
        });

        balls.push({
            x: 100,
            y: 310,
            oldX: this.x,
            oldY: this.y,
            speedX: -MOVE_SPEED * 2,
            speedY: -MOVE_SPEED * 2
        });

        balls.push({
            x: 410,
            y: 100,
            oldX: this.x,
            oldY: this.y,
            speedX: MOVE_SPEED * 3,
            speedY: -MOVE_SPEED * 3
        });

        balls.push({
            x: 100,
            y: 100,
            oldX: this.x,
            oldY: this.y,
            speedX: -MOVE_SPEED * 4,
            speedY: MOVE_SPEED * 4
        });

        return balls;
    }
}