namespace Computers.Lib
{
    using System;

    public class VideoCard : IVideoCard
    {
        private readonly bool isColor;

        public VideoCard(bool videocardIsColor)
        {
            this.isColor = videocardIsColor;
        }

        public void Draw(string message)
        {
            if (this.isColor)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}