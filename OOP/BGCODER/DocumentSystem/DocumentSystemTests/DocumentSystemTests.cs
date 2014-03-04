using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentSystemTests
{
    [TestClass]
    public class DocumentSystemTests
    {
        [TestMethod]
        public void ZeroTestMainMethod()
        {
            var streamWriter = new StreamWriter(@"..\..\result0.txt");
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(@"..\..\test.000.001.in.txt"));
                Console.SetOut(streamWriter);
                DocumentSystem.DocumentSystem.Main();
            }

            Assert.AreEqual(new StreamReader(@"..\..\result0.txt").ReadToEnd(),
                new StreamReader(@"..\..\test.000.001.out.txt").ReadToEnd());
        }

        [TestMethod]
        public void TestAllMainMethod()
        {
            for (int i = 1; i <= 30; i++)
            {

                int testNumber = i;
                var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
                using (streamWriter)
                {
                    Console.SetIn(new StreamReader(string.Format(@"..\..\test.0{0:D2}.in.txt", testNumber)));
                    Console.SetOut(streamWriter);
                    DocumentSystem.DocumentSystem.Main();
                }

                Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                    new StreamReader(string.Format(@"..\..\test.0{0:D2}.out.txt", testNumber)).ReadToEnd());
                
            }
        }
       
    }
}
