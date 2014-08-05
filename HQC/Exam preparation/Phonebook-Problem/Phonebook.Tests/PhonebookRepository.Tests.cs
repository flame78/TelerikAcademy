using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phonebook.Tests
{
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    using Phonebook.Lib;
    using Phonebook.Lib.Contracts;
    using Phonebook.Lib.Formater;

    [TestClass]
    public class UnitTest1
    {

        private IPhonebookRepository phonebookRepository; 

        [TestInitialize]

        public void Initialize()
        {
            this.phonebookRepository = new PhonebookRepository(new PhoneNumberFormater());
            for (int i = 0; i < 10000; i++)
            {
                this.phonebookRepository.AddPhone(i.ToString(),new[] {i.ToString()});
            }
        }


        [TestMethod]
        public void CheckForCorrectAdding()
        {
            var entries = this.phonebookRepository.ListEntries(0, 10000);
            Assert.AreEqual(10000, entries.Count());
        }
    }
}
