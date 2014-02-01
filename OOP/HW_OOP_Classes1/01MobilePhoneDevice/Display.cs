using _01MobilePhoneDevice;
using System;

namespace _01MobilePhoneDevice
{
    public class Display
    {
        public enum ColorDepth
        {
            _1Bit, _4Bit, _8Bit, _15Bit, _16Bit, _24Bit, _32Bit
        }

        private readonly double size;
        private readonly ColorDepth colors;


        public Display() { }

        public Display(double sizeInInches) : this(sizeInInches, 0) { }

        public Display(double sizeInInches, ColorDepth colorDepth)
        {
            if (sizeInInches < 0)
                throw new ArgumentOutOfRangeException("Can not use negative size");
            else
                this.size = sizeInInches;

            this.colors = colorDepth;
        }



        public double SizeInInches
        {
            get
            {
                return this.size;
            }
        }

        public ColorDepth Colors { get { return this.colors; } }

        public override string ToString()
        {
            return string.Format("Display Size in Inches {0}, Color Depth {1}", this.size,this.colors);
        }
    }
}
