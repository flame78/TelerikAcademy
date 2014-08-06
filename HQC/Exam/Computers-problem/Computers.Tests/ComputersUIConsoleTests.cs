namespace Computers.Tests
{
    using System;
    using System.IO;

    using Computers.UI.Console;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ComputersUIConsoleTests
    {
        [TestClass]
        public class TestPhonebookConsoleClient
        {
            [TestMethod]
            public void TestDefaultScenarioForHPWithoutGame()
            {
                const string ResultTestFilePath = @"..\..\TestsData\ResultDefaultScenarioHP.txt";
                const string InputTestFilePath = @"..\..\TestsData\InputDefaultScenarioHP.txt";

                ConsoleTest(ResultTestFilePath, InputTestFilePath);
            }

            [TestMethod]
            public void TestDefaultScenarioForDellWithoutGame()
            {
                const string ResultTestFilePath = @"..\..\TestsData\ResultDefaultScenarioDell.txt";
                const string InputTestFilePath = @"..\..\TestsData\InputDefaultScenarioDell.txt";

                ConsoleTest(ResultTestFilePath, InputTestFilePath);
            }

            private static void ConsoleTest(string resultTestFilePath, string inputTestFilePath)
            {
                string expected;

                using (var sr = new StreamReader(resultTestFilePath))
                {
                    expected = sr.ReadToEnd();
                }

                var result = new StringWriter();

                Console.SetOut(result);
                Console.SetIn(new StreamReader(inputTestFilePath));

                Program.Main();

                Assert.AreEqual(expected, result.ToString());
            }
        }
    }
}