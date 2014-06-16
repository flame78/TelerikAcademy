namespace Methods
{
    using System;

    public static class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides of the triangle can not be negative.");
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArithmeticException("These sides can not form a triangle");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static string DigitToWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentOutOfRangeException("digit must be between 0 and 9");
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("еlements must be at least one");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static string FormatNumber(object number, string format = "f")
        {
            string formatedNumber;

            if (format == "f")
            {
                formatedNumber = string.Format("{0:f2}", number);
            }
            else if (format == "%")
            {
                formatedNumber = string.Format("{0:p0}", number);
            }
            else if (format == "r")
            {
                formatedNumber = string.Format("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format - " + format);
            }

            return formatedNumber;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine(FormatNumber(0.75, "f"));
            Console.WriteLine(FormatNumber(0.75, "%"));
            Console.WriteLine(FormatNumber(2.30, "r"));

            var line = new Line(3, -1, 3, 2.5);

            Console.WriteLine(line.Length);
            Console.WriteLine("Horizontal? " + line.IsHorizontal);
            Console.WriteLine("Vertical? " + line.IsVertical);

            Student peter = new Student("Peter", "Ivanov", "17.12.1992", "From Sofia");
            Student stella = new Student("Stella", "Markova", "03.11.1993", "From Vidin, gamer, high results");

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
