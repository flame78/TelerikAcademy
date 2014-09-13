namespace Phonebook.Tests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phonebook.Lib;
    using Phonebook.Lib.Contracts;

    [TestClass]
    public class PhonebookRepositorySlowTests
    {
        private IPhonebookRepository phonebookRepository;

        [TestInitialize]
        public void Initialize()
        {
            this.phonebookRepository = new PhonebookRepositorySlow();
            for (var i = 0; i < 1000; i++)
            {
                this.phonebookRepository.AddPhone(i.ToString(), new[] { i.ToString() });
            }
        }

        [TestMethod]
        public void CheckForCorrectAddingWithSlowRepository()
        {
            var entries = this.phonebookRepository.ListEntries(0, 1000);
            Assert.AreEqual(1000, entries.Count());
        }
    }
}