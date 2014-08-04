namespace Phonebook.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PhonebookConsoleClient;

    [TestClass]
    public class TestPhonebookConsoleClient
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

            PhonebookConsoleClient.Main();

            Assert.AreEqual(expected, result.ToString());
        }
    }

    [TestClass]
    public class PhonebookRepositorysTests
    {
        private IList<PhonebookEntry> phonebookRepositoryData;

        // public CarsControllerTests()
        // : this(new JustMockCarsRepository())
        // {
        // }

        // public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        // {
        // this.carsData = carsDataMock.CarsData;
        // }

        // [TestInitialize]
        // public void CreateController()
        // {
        // this.controller = new CarsController(this.carsData);
        // }
    }
}