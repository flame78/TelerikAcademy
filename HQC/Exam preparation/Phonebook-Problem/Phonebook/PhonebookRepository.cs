namespace Phonebook.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Lib.Contracts;

    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        protected readonly MultiDictionary<string, PhonebookEntry> EntriesByNumber;

        protected readonly IPhoneNumberFormater NumberFormater;

        protected readonly OrderedSet<PhonebookEntry> SortedEntries;

        protected readonly Dictionary<string, PhonebookEntry> UnsortedEntries;

        public PhonebookRepository(IPhoneNumberFormater formater, IEnumerable<PhonebookEntry> entries)
            : this(formater)
        {
            foreach (var entry in entries)
            {
                this.AddPhone(entry.Name, entry.Phones);
            }
        }

        public PhonebookRepository(IPhoneNumberFormater formater)
        {
            this.UnsortedEntries = new Dictionary<string, PhonebookEntry>();
            this.EntriesByNumber = new MultiDictionary<string, PhonebookEntry>(false);
            this.SortedEntries = new OrderedSet<PhonebookEntry>();
            this.NumberFormater = formater;
        }

        public bool AddPhone(string name, IEnumerable<string> numbers)
        {
            if (name == null || numbers == null)
            {
                throw new ArgumentNullException("Null argument cant be added");
            }

            var formatedNumbers = new List<string>(numbers.Count());
            formatedNumbers.AddRange(numbers.Select(number => this.NumberFormater.Format(number)));

            var nameInLowerInvariant = name.ToLowerInvariant();

            PhonebookEntry entry;

            var isNameAlredyExist = this.UnsortedEntries.TryGetValue(nameInLowerInvariant, out entry);

            if (!isNameAlredyExist)
            {
                entry = new PhonebookEntry(name, new SortedSet<string>());
                this.UnsortedEntries.Add(nameInLowerInvariant, entry);
                this.SortedEntries.Add(entry);
            }

            foreach (var number in formatedNumbers)
            {
                this.EntriesByNumber.Add(number, entry);
            }

            entry.Phones.UnionWith(formatedNumbers);
            return !isNameAlredyExist;
        }

        public int ChangePhone(string currentNumber, string newNumber)
        {
            currentNumber = this.NumberFormater.Format(currentNumber);
            newNumber = this.NumberFormater.Format(newNumber);

            var found = this.EntriesByNumber[currentNumber].ToList();
            foreach (var entry in found)
            {
                entry.Phones.Remove(currentNumber);
                this.EntriesByNumber.Remove(currentNumber, entry);

                entry.Phones.Add(newNumber);
                this.EntriesByNumber.Add(newNumber, entry);
            }

            return found.Count;
        }

        public IEnumerable<PhonebookEntry> ListEntries(int start, int count)
        {
            if (start < 0 || start + count > this.UnsortedEntries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            var list = new PhonebookEntry[count];

            for (var i = start; i <= start + count - 1; i++)
            {
                var entry = this.SortedEntries[i];
                list[i - start] = entry;
            }

            return list;
        }
    }
}