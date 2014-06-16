namespace Methods
{
    using System;

    public class Line
    {
        public Line(double x1, double y1, double x2, double y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        public Line()
        {
        }

        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }
        
        public double Length
        {
            get
            {
                double length = Math.Sqrt(
                    ((this.X2 - this.X1) * (this.X2 - this.X1)) + 
                    ((this.Y2 - this.Y1) * (this.Y2 - this.Y1)));

                return length;
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return this.Y1 == this.Y2;
            }
        }

        public bool IsVertical
        {
            get
            {
                return this.X1 == this.X2;
            }
        }
    }
}
