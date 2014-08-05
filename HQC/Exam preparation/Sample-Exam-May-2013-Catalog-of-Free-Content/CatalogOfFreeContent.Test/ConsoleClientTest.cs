namespace CatalogOfFreeContent.Test
{
    using System;
    using System.IO;

    using CatalogOfFreeContent.ConsoleClient;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleCLientTest
    {
        [TestMethod]
        public void TestDefaultScenario()
        {
            const string ResultTestFilePath = @"..\..\TestsData\ResultDefaultScenario.txt";
            const string InputTestFilePath = @"..\..\TestsData\InputDefaultScenario.txt";

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

            ConsoleClient.Main();

            Assert.AreEqual(expected, result.ToString());
        }
    }
}