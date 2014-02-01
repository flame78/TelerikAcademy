using System;
using System.Threading;

class FallingRocks
{
    static void Main()
    {
        int width = 60, height = 20; // Size of console window
        char symbOfStone = '^';
        var r = new Random(); 
        int lives = 2, key = 0, numberOfStones, posOfStone, pos = width / 2 - 1, speed = 200;
        int pas = 0, startSpeed = speed;
        string[] line = new string[height + 1];

        Console.WindowHeight = height;
        Console.WindowWidth = width;


        for (int i = 0; i <= height; i++)
        {
            line[i] = new string(' ', width);

        }

        line[1] = new string('-', width);
        Console.SetCursorPosition(0, 2);
        Console.Write(line[1]);


        for (int i9 = 0; i9 < int.MaxValue; i9++)
        {
            Thread.Sleep(1);

            if (pas >= speed)
            {
                Console.SetCursorPosition(0, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Level:{0}    Score:{1}    Lives:{2}", (startSpeed - speed) / 10 + 1, (startSpeed - speed) * i9 / 1000, lives);

                numberOfStones = r.Next(width / 20);
                line[2] = new string(' ', width);


                for (int i = 0; i < numberOfStones; i++)
                {
                    posOfStone = r.Next(width);

                    // Stone types
                    //  ^, @, *, &, +, %, $, #, !, ., ;, -
                    switch (r.Next(12))
                    {
                        case 0:
                            symbOfStone = '^';
                            break;
                        case 1:
                            symbOfStone = '@';
                            break;
                        case 2:
                            symbOfStone = '*';
                            break;
                        case 3:
                            symbOfStone = '&';
                            break;
                        case 4:
                            symbOfStone = '+';
                            break;
                        case 5:
                            symbOfStone = '%';
                            break;
                        case 6:
                            symbOfStone = '$';
                            break;
                        case 7:
                            symbOfStone = '#';
                            break;
                        case 8:
                            symbOfStone = '!';
                            break;
                        case 9:
                            symbOfStone = '.';
                            break;
                        case 10:
                            symbOfStone = ';';
                            break;
                        default:
                            symbOfStone = '-';
                            break;
                    }


                    line[2] = line[2].Insert(posOfStone, Convert.ToString(symbOfStone));
                }

                Console.ForegroundColor = (ConsoleColor)(r.Next(15) + 1);
                for (int i = height; i > 2; i--)
                {
                    line[i] = line[i - 1];
                    Console.SetCursorPosition(0, i);
                    Console.Write(line[i]);
                }

                pas = 0;


            }

            if ((i9 % 1000) == 0) speed--;

            pas++;

            if (Console.KeyAvailable == true)
            {
                key = (int)Console.ReadKey().Key;
                if (key == 37)
                    if (pos > 0)
                    {
                        pos--;
                        Console.SetCursorPosition(pos + 3, height);
                        Console.Write(" ");
                    }
                if (key == 39)
                    if (pos < width - 3)
                    {
                        pos++;
                        Console.SetCursorPosition(pos - 1, height);
                        Console.Write(" ");
                    }
                if (key == 27) break;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(pos, height);
            Console.Write("(0)");

            line[0] = line[height].Substring(pos, 3);
            if (line[0] != "   ")
            {
                if (--lives < 0)
                {
                    Console.SetCursorPosition(width / 2 - 5, height / 2);
                    Console.WriteLine("GAME OVER");
                    break;
                }
                else
                {
                    for (int i = 0; i <= height; i++)
                    {
                        line[i] = new string(' ', width);

                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }


}

