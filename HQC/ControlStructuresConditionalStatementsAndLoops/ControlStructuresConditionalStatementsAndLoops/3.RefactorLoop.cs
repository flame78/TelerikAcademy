namespace ControlStructuresConditionalStatementsAndLoops
{
    using System;

    public static class RefactorLoop
    {
        public void Loop()
        {
            bool valueFound = false;

            int[] array = new int[100];
            int expectedValue = 666;

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 != 0)
                {
                    Console.WriteLine(array[i]);
                }
                else
                {
                    Console.WriteLine(array[i]);

                    if (array[i] == expectedValue)
                    {
                        valueFound = true;
                        break;
                    }
                }
            }

            // More code here
            if (valueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}