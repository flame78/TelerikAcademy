namespace Computers.Lib
{
    public class Ram
    {
        private int amount;

        private int value;

        public Ram(int amountOfRam)
        {
            this.amount = amountOfRam;
        }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}