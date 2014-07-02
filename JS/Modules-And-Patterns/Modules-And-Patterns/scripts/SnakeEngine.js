/// <reference path="../libs/kinetic-v5.1.0.js" />
/// <reference path="SnakeDrawer.js" />
/// <reference path="Snake.js" />
'use strict';
var snakeEngine = (function () {
    var COLS = 55;
    var ROWS = 30;
    var WIDTH = 770;
    var HEIGHT = 420;
    var CONTAINER = 'container';
    var snake; 
    var stage;
    var stones;
    var appleItervalID;

    var snakeLayer = new Kinetic.Layer();
    var backgroundLayer = new Kinetic.Layer();
    
    setControls();

    function startGame() {
        
        snakeLayer.destroy();
        backgroundLayer.destroy();

        if (stage) stage.clear();

        stage = new Kinetic.Stage({
            container: CONTAINER,
            width: WIDTH,
            height: HEIGHT
        });
       
        stones = [];
        snake = snakeClass(28, 15 * 14, 10, 1);
        generateStones(stones);
        drawBackground(backgroundLayer, stones);
        window.requestAnimationFrame(frame);
        appleItervalID = setInterval(randomApple, 2000);
    }

    function randomApple() {
        drawer.apple(random(1, COLS - 1), random(1, ROWS - 1), backgroundLayer);
        stage.add(backgroundLayer);
        clearInterval(appleItervalID);
        appleItervalID = setInterval(randomApple, 10000);
    }

    function frame() {
        snake.update();
        var snakeBody = snake.getSnakeData();
        snakeLayer.clear();
        for (var cell = 0; cell < snakeBody.length; cell++) {
            drawer.snake(cell, snakeBody[cell][0], snakeBody[cell][1], snakeLayer)
        }
        if (!hasCollision(snakeBody)) {
            stage.add(snakeLayer);
            window.requestAnimationFrame(frame);
        }
    }

    function hasCollision(snakeBody) {
        var collision = backgroundLayer.getIntersection({
            x: snakeBody[0][0] + 7,
            y: snakeBody[0][1] + 7
        }).getName();

        if (collision == 'stone' || collision == 'border') {
            clearInterval(appleItervalID);
            startGame();
            return true;
        }

        if (collision == 'apple') {
            backgroundLayer.getIntersection({
                x: snakeBody[0][0] + 7,
                y: snakeBody[0][1] + 7
            }).destroy();
            randomApple();
            snake.increaseLength();
        }
        return false;
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