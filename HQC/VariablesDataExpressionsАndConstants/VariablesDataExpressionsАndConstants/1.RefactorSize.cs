namespace RefactoredSize
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative Width");
                }
            }
        }

        public double Height
        {
            get;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative Height");
                }
            }
        }

        public Size RotatedSize(double angleOfRotation)
        {
            double sinOfAngle = Math.Abs(Math.Sin(angleOfRotation));
            double cosOfAngle = Math.Abs(Math.Cos(angleOfRotation));
            double newWidth = (cosOfAngle * this.width) + (sinOfAngle * this.height);
            double newHeight = (sinOfAngle * this.height) + (cosOfAngle * this.width);

            Size rotatedSize = new Size(newWidth, newHeight);

            return rotatedSize;
        }
    }
}