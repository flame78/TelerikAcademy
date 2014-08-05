namespace Phonebook.Lib
{
    using System;

    using Phonebook.Lib.Contracts;

    public class PhonebookRepositoryWithRemove : PhonebookRepository
    {
        public PhonebookRepositoryWithRemove(IPhoneNumberFormater formater)
            : base(formater)
        {
        }

        public bool Remove(string phoneNumber)
        {
            if (phoneNumber != this.NumberFormater.Format(phoneNumber))
            {
                throw new ArgumentOutOfRangeException("Phone Number must be in canonical phone number format");
            }

            if (!this.EntriesByNumber.ContainsKey(phoneNumber))
            {
                return false;
            }

            var entriesWithNumberToRemove = this.EntriesByNumber[phoneNumber];

            foreach (var entry in entriesWithNumberToRemove)
            {
                entry.Phones.Remove(phoneNumber);
                if (entry.Phones.Count == 0)
                {
                    this.SortedEntries.Remove(entry);
                    this.UnsortedEntries.Remove(entry.Name.ToLowerInvariant());
                }
            }

            this.EntriesByNumber.Remove(phoneNumber);

            return true;
        }
    }
}