
if (CanvasRenderingContext2D.prototype.drawCircle === undefined) {
    CanvasRenderingContext2D.prototype.drawCircle = function (centerX, centerY, radius, border, fill) {
        ///<param name="x">X coordinate of circle's center</param>
        ///<param name="y">Y coordinate of circle's center</param>
        ///<param name="radius">Radius</param>
        ///<param name="startAngle">Clockwise in Radians</param>
        ///<param name="endAngle">Clockwise in Radians</param>
        ///<param name="anticlockwise" type="bool">true if the path south be drawn anticlickwise otherwise omit the value or false</param>

        this.beginPath();
        this.arc(centerX, centerY, radius, 0, Math.PI * 2);

        if (fill) {
            this.fill();
        }

        if (border) {
            this.stroke();
        }
    }
}

if (CanvasRenderingContext2D.prototype.drawEllipse === undefined) {
    CanvasRenderingContext2D.prototype.drawEllipse = function (centerX, centerY, radiusX, radiusY, border, fill, rotation) {
        this.save();
        this.translate(centerX, centerY);
        this.rotate(rotation * Math.PI / 180);
        this.scale(1, radiusY / radiusX);
        this.beginPath();
        this.arc(0, 0, radiusX, 0, Math.PI * 2);


        if (fill) {
            this.fill();
        }

        if (border) {
            this.stroke();
        }

        this.restore();
    }
}
