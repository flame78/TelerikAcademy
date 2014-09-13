namespace Computers.Lib
{
    using System;

    using Computers.Lib.Contracts;

    public class Motherboard : IMotherboard
    {
        private static readonly Random Random = new Random();

        private readonly byte numberOfBits;

        private readonly Ram ram;

        private readonly IVideoCard videoCard;

        public Motherboard(byte numberOfCores, byte numberOfBits, Ram ram, IVideoCard videoCard)
        {
            this.numberOfBits = numberOfBits;
            this.ram = ram;
            this.NumberOfCores = numberOfCores;
            this.videoCard = videoCard;
        }

        private byte NumberOfCores { get; set; }

        public int LoadRamValue()
        {
            return this.ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string message)
        {
            this.videoCard.Draw(message);
        }

        public void SquareNumber()
        {
            if (this.numberOfBits == 32)
            {
                this.SquareNumber(500);
            }

            if (this.numberOfBits == 64)
            {
                this.SquareNumber(1000);
            }

            if (this.numberOfBits == 128)
            {
                this.SquareNumber(2000);
            }
        }

        internal void RandomNumber(int from, int to)
        {
            var randomNumber = Random.Next(from, to + 1);
            this.ram.SaveValue(randomNumber);
        }

        private void SquareNumber(int max)
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > max)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                // This is Bottleneck
                var result = 0;
                for (var i = 0; i < data; i++)
                {
                    result += data;
                }

                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, result));
            }
        }
    }
}