namespace Computers.Tests
{
    using System;

    using Computers.Lib;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vc = new Mock<IVideoCard>();
            string result;
            vc.Setup(h => h.Draw(It.IsAny<string>())).Callback<string>(r => result = r);
            var motherboard = new Motherboard(2, 32, new Ram(1), vc.Object);

            motherboard.SaveRamValue(1000);
            motherboard.SquareNumber();

            Assert.IsTrue(true);
        }
    }
}