/* 
1. Write functions for working with shapes in standard 
Planar coordinate system
 Points are represented by coordinates P(X, Y)
 Lines are represented by two points, marking their 
beginning and ending
 L(P1(X1,Y1), P2(X2,Y2))
 Calculate the distance between two points
 Check if three segment lines can form a triangle
*/
function planarCoordinateSystem() {

    debugger;

    // Input data http://www.mathsisfun.com/algebra/distance-2-points.html

    var p1 = new Point(3, 2);
    var p2 = new Point(9, 7);
    var p3 = new Point(9, 2);

    var l1 = new Line(p1, p2);
    var l2 = new Line(p2, p3);
    var l3 = new Line(p3, p1);

    console.log(distanceBetweenTwoPoints(p1, p2));

    console.log(checkThreeLinesCanFormTriangle(l1,l2,l3));

    function checkThreeLinesCanFormTriangle(l1, l2, l3) {
        if (l1 instanceof Line && l2 instanceof Line && l3 instanceof Line) {
            if (l1.length < l2.length + l3.length) {
                if (l2.length < l1.length + l3.length) {
                    if (l3.length < l1.length + l2.length) {
                        return true;
                    }
                }
            }
        } else {
            throw 'Input must be trhee lines'
        }
        return false;
    }
    function distanceBetweenTwoPoints(point1, point2) {

        if (point1 instanceof Point && point2 instanceof Point) {
            return Math.sqrt((point1.x - point2.x) * (point1.x - point2.x) + (point1.y - point2.y) * (point1.y - point2.y));
        } else {
            throw "Can calculate distance only between two Points";
        }
    }



    function Line(startPoint, endPoint) {
        if (startPoint instanceof Point && endPoint instanceof Point) {

            this.startPoint = new Point(startPoint.x, startPoint.y);
            this.endPoint = new Point(endPoint.x, endPoint.y);
            this.length = distanceBetweenTwoPoints(this.startPoint, this.endPoint);
            return this;

        } else {
            throw "Line can make only with two Points";
        }
    }
    function Point(x, y) {

        if (isNaN(x) || isNaN(y)) {
            throw "Can't make Point with NaN";
        }

        this.x = x;
        this.y = y;

        this.toString = function () { return 'x=' + x + '; y=' + y; }

        return this;

    }
}