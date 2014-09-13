namespace Phonebook.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phonebook.Lib;
    using Phonebook.Lib.Formater;

    [TestClass]
    public class PhonebookRepositoryWithRemoveTest
    {
        [TestMethod]
        public void TestRemoveForRemoveEntryWhenItIsEmpty()
        {
            var phonebookRepository = new PhonebookRepositoryWithRemove(new PhoneNumberFormater());

            phonebookRepository.AddPhone("Pesho", new[] { "112", "113" });
            phonebookRepository.AddPhone("Gosho", new[] { "113" });
            phonebookRepository.Remove("+359113");

            phonebookRepository.ListEntries(0, 1);
        }
    }
}