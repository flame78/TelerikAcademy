namespace Computers.Lib.Contracts
{
    public interface IComputer
    {
        void ChargeBattery(int percentage);

        void Play(int guessNumber);

        void Process(int data);
    }
}