/// <reference path="RandomDivs.js" />
window.onload = function () {
    randomDivs(5);

    var radius=50;
    var angle=0 ;
    var divs = document.getElementsByTagName('div');

    var intervalMove = setInterval(function() {
        angle+=Math.PI /20;
        if (angle>=Math.PI*2) {
            angle=0;
        }
        rotateDivs(divs, radius, angle);
    }      
        , 100);
}

function rotateDivs(divs, radius, angle) {

    if (divs[0].cx === undefined) {
        for (var i = 0, length = divs.length; i < length; i++) {
            divs[i].cx = parseInt(divs[i].style.left)- (Math.cos(angle)*radius );
            divs[i].cy = parseInt(divs[i].style.top) - (Math.sin(angle) * radius);
        }
    }

    for (var i = 0,length=divs.length; i < length; i++) {
        divs[i].style.left = (divs[i].cx + (Math.cos(angle)*radius )) + 'px';
        divs[i].style.top = (divs[i].cy + (Math.sin(angle)* radius)) + 'px';
    }
    

}