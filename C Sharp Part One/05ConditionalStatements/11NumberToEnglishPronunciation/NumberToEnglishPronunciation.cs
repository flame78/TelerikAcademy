//* Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
//    0  "Zero"
//    273  "Two hundred seventy three"
//    400  "Four hundred"
//    501  "Five hundred and one"
//    711  "Seven hundred and eleven"

using System;

class NumberToEnglishPronunciation
{
    static void Main()
    {
        int number;
        string input;
        string englishPronunciation = "";
        string firstDigit = "", secondDigit = "", last2Digit = "";

        do
        {

            Console.Write("Enter number in the range [0...999]: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out number))
                if (number <= 999)
                    if (number >= 0) break;
        } while (true);

        input = input.PadLeft(3);

        firstDigit = input.Substring(0, 1);
        secondDigit = input.Substring(1, 1);
        last2Digit = input.Substring(1, 2);

        switch (firstDigit)
        {
            case "1":
                englishPronunciation += "One hundred";
                break;
            case "2":
                englishPronunciation += "Two hundred";
                break;
            case "3":
                englishPronunciation += "Three hundred";
                break;
            case "4":
                englishPronunciation += "Four hundred";
                break;
            case "5":
                englishPronunciation += "Five hundred";
                break;
            case "6":
                englishPronunciation += "Six hundred";
                break;
            case "7":
                englishPronunciation += "Seven hundred";
                break;
            case "8":
                englishPronunciation += "Eight hundred";
                break;
            case "9":
                englishPronunciation += "Nine hundred";
                break;

            default:
                break;

        }

        if (Convert.ToInt16(last2Digit) > 0 && Convert.ToInt16(last2Digit) < 20 && number > 99) englishPronunciation += " and ";
        
        switch (secondDigit)
        {
                
            case "2":
                englishPronunciation += " Twenty ";
                last2Digit = input.Substring(2, 1);
                break;
            case "3":
                englishPronunciation += " Thirty ";
                last2Digit = input.Substring(2, 1);
                break;
            case "4":
                englishPronunciation += " Forty ";
                last2Digit = input.Substring(2, 1);
                break;
            case "5":
                englishPronunciation += " Fifty ";
                last2Digit = input.Substring(2, 1);
                break;
            case "6":
                englishPronunciation += " Sixty ";
                last2Digit = input.Substring(2, 1);
                break;
            case "7":
                englishPronunciation += " Seventy ";
                last2Digit = input.Substring(2, 1);
                break;
            case "8":
                englishPronunciation += " Eighty ";
                last2Digit = input.Substring(2, 1);
                break;
            case "9":
                englishPronunciation += " Ninety ";
                last2Digit = input.Substring(2, 1);
                break;

            default:
                break;

        }

      
    switch (Convert.ToInt16(last2Digit))
            {
                case 1:
                    englishPronunciation += "One";
                    break;
                case 2:
                    englishPronunciation += "Two";
                    break;
                case 3:
                    englishPronunciation += "Three";
                    break;
                case 4:
                    englishPronunciation += "Four";
                    break;
                case 5:
                    englishPronunciation += "Five";
                    break;
                case 6:
                    englishPronunciation += "Six";
                    break;
                case 7:
                    englishPronunciation += "Seven";
                    break;
                case 8:
                    englishPronunciation += "Eight";
                    break;
                case 9:
                    englishPronunciation += "Nine";
                    break;
                case 10:
                    englishPronunciation += "Ten";
                    break;
                case 11:
                    englishPronunciation += "Eleven";
                    break;
                case 12:
                    englishPronunciation += "Twelve";
                    break;
                case 13:
                    englishPronunciation += "Thirteen";
                    break;
                case 14:
                    englishPronunciation += "Fourteen";
                    break;
                case 15:
                    englishPronunciation += "Fiveteen";
                    break;
                case 16:
                    englishPronunciation += "Sixteen";
                    break;
                case 17:
                    englishPronunciation += "Seventeen";
                    break;
                case 18:
                    englishPronunciation += "Eighteen";
                    break;
                case 19:
                    englishPronunciation += "Nineteen";
                    break;
                default:
                    break;

            }

    if (number==0) englishPronunciation += "Zero";
    


        Console.WriteLine(englishPronunciation);
    }
}

