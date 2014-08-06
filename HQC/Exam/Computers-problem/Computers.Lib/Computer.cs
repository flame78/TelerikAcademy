namespace Computers.Lib
{
    using System.Collections.Generic;

    // TODO: Composite Design Patern
    public class Computer
    {
        private readonly Battery battery;

        private readonly Motherboard motherboard;

        private IEnumerable<HardDriver> hardDrives;

        public Computer(Motherboard motherboard, IEnumerable<HardDriver> hardDrives, Battery battery)
            : this(motherboard, hardDrives)
        {
            this.battery = battery;
        }

        public Computer(Motherboard motherboard, IEnumerable<HardDriver> hardDrives)
        {
            this.motherboard = motherboard;
            this.hardDrives = hardDrives;
        }

        public void Play(int guessNumber)
        {
            this.motherboard.RandomNumber(1, 10);
            var number = this.motherboard.LoadRamValue();

            if (number != guessNumber)
            {
                this.motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.motherboard.DrawOnVideoCard("You win!");
            }
        }

        public void ChargeBattery(int percentage)
        {
            if (this.battery == null)
            {
                return;
            }

            this.battery.Charge(percentage);

            this.motherboard.DrawOnVideoCard(string.Format("Battery status: {0}%", this.battery.Percentage));
        }

        public void Process(int data)
        {
            this.motherboard.SaveRamValue(data);

            // TODO: Fix it
            this.motherboard.SquareNumber();
        }
    }
}