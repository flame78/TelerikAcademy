/// <reference path="../libs/kinetic-v5.1.0.js" />
/// <reference path="SnakeDrawer.js" />
/// <reference path="Snake.js" />

var snakeEngine = (function () {
    var COLS = 55;
    var ROWS = 30;
    var WIDTH = 770;
    var HEIGHT = 420;
    var CONTAINER = 'container';
    var gameField = [];
   
    var snakeLayer = new Kinetic.Layer();
    var snake = snakeClass(28, 15 * 14, 10, 1);
    
    var stage = new Kinetic.Stage({
        container: CONTAINER,
        width: WIDTH,
        height: HEIGHT
    });

    var backgroundLayer = new Kinetic.Layer();

    var stones = []

    setGameFieldSize();
    generateStones(stones);
    drawBackground(backgroundLayer, stones);

    setControls();

    function startGame(){
        window.requestAnimationFrame(frame);
        setTimeout(randomApple, 2000);
    }

    function randomApple() {
        drawer.apple(random(1, COLS - 1), random(1, ROWS - 1), backgroundLayer);
        stage.add(backgroundLayer);
        setTimeout(randomApple, 10000);
    }

    function frame() {
        snake.update();
        var snakeBody = snake.getSnakeData();
        snakeLayer.clear();
        for (var cell = 0; cell < snakeBody.length; cell++) {
            drawer.snake(cell, snakeBody[cell][0], snakeBody[cell][1], snakeLayer)
        }
        checkForCollision(snakeBody)
        stage.add(snakeLayer);

            window.requestAnimationFrame(frame);
    }

    function checkForCollision(snakeBody) {
        var collision = backgroundLayer.getIntersection({
            x: snakeBody[0][0] + 7,
            y: snakeBody[0][1] + 7
        })

        if (collision.getName() == 'apple') {
            console.log(collision);
            drawer.apple(-1, -1, backgroundLayer);
            stage.add(backgroundLayer);
        }
    }

    function setControls() {
        document.addEventListener('keydown', function (ev) {
            switch (ev.keyCode) {
                case 37:
                    snake.moveLeft();
                    break;
                case 38:
                    snake.moveUp();
                    break;
                case 39:
                    snake.moveRight();
                    break;
                case 40:
                    snake.moveDown();
                    break;
                default:
                    console.log(ev.keyCode);
            }
        });
    }

    function drawBackground(layer) {

        var rect = new Kinetic.Rect({
            x: 0,
            y: 0,
            width: COLS * 14,
            height: ROWS * 14,
            fill: 'darkgreen',
        });

        layer.add(rect);
        
        for (var i = 0; i < ROWS; i++) {
            drawer.border(0, i, layer);
            drawer.border(COLS-1, i, layer);
        }

        for (var i = 0; i < COLS; i++) {
            drawer.border(i, ROWS-1, layer);
            drawer.border(i, 0, layer);
        }

        for (var i = 0; i < stones.length; i++) {
            drawer.stone(stones[i][0], stones[i][1], layer);
        }

        stage.add(layer);
    }

    function generateStones(stones) {
        var numberOfStones = random(10, 40);

        for (var i = 0; i < numberOfStones; i++) {
            stones.push([random(1, COLS - 1), random(1, ROWS - 1)]);
        }
    }

    function random(from, to)
    {
        return (Math.random()*(to-from)+from) | 0
    }

    function setGameFieldSize() {
        if (window.innerWidth / window.innerHeight < WIDTH / HEIGHT) {
            document.getElementById(CONTAINER).style.zoom = window.innerWidth / WIDTH;
        }
        else {
            document.getElementById(CONTAINER).style.zoom = window.innerHeight / HEIGHT;
        }
        document.body.style.overflow = 'hiden';
    }

    return {
        startGame:startGame
    }
}());