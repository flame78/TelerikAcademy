namespace Phonebook.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phonebook.Lib;
    using Phonebook.Lib.Contracts;
    using Phonebook.Lib.Formater;

    [TestClass]
    public class PhonebookRepositoryTest
    {
        private IPhonebookRepository phonebookRepository;

        [TestInitialize]
        public void Initialize()
        {
            this.phonebookRepository = new PhonebookRepository(new PhoneNumberFormater());
            for (var i = 0; i < 1000; i++)
            {
                this.phonebookRepository.AddPhone(i.ToString(), new[] { "0" + i });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddWithNullForNameTest()
        {
            this.phonebookRepository.AddPhone(null, new[] { "112" });
        }

        [TestMethod]
        public void TestChangePhoneReturnResultNumberOfChanged()
        {
            var changedNumbers = this.phonebookRepository.ChangePhone("00", "11");
            Assert.AreEqual(1, changedNumbers);
        }

        [TestMethod]
        public void CheckForCorrectAdding()
        {
            var entries = this.phonebookRepository.ListEntries(0, 1000);
            Assert.AreEqual(1000, entries.Count());
        }
    }
}