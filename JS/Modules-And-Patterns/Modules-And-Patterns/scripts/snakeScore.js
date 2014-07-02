/// <reference path="C:\Users\Ivan\Desktop\github\JS\Modules-And-Patterns\Modules-And-Patterns\libs/kinetic-v5.1.0.js" />
'use strict';
var snakeScore = (function (width, height) {

    var resultKJS = new Kinetic.Text({
        x:width*3/4,
        y: height - 35,
        fontSize: 24,
        fontFamily: 'Calibri',
        fill: 'white'
    });

    var levelKJS = new Kinetic.Text({
        x: width * 1 / 4,
        y: height - 15
    });

    var livesKJS = new Kinetic.Text({
        x: width * 2 / 4,
        y: height - 15
    });

    function result(score, layer, stage) {
        resultKJS.setText('Score: ' + score);
        layer.add(resultKJS);
        stage.add(layer);
    }

    return {
        result:result
    }
}(770,462));