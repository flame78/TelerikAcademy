namespace Phonebook.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Lib.Contracts;

    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly Dictionary<string, PhonebookEntry> dict;

        private readonly MultiDictionary<string, PhonebookEntry> multidict;

        private readonly OrderedSet<PhonebookEntry> sorted;
        private IPhoneNumberFormater formater;

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
            this.dict = new Dictionary<string, PhonebookEntry>();
            this.multidict = new MultiDictionary<string, PhonebookEntry>(false);
            this.sorted = new OrderedSet<PhonebookEntry>();
            this.formater = formater;
        }

        public bool AddPhone(string name, IEnumerable<string> numbers)
        {
            var formatedNumbers = new List<string>(numbers.Count());
            formatedNumbers.AddRange(numbers.Select(number => this.formater.Format(number)));

            var nameInLowerInvariant = name.ToLowerInvariant();

            PhonebookEntry entry;

            var notNameAlredyExist = !this.dict.TryGetValue(nameInLowerInvariant, out entry);

            if (notNameAlredyExist)
            {
                entry = new PhonebookEntry(name, new SortedSet<string>());
                this.dict.Add(nameInLowerInvariant, entry);
                this.sorted.Add(entry);
            }

            foreach (var number in formatedNumbers)
            {
                this.multidict.Add(number, entry);
            }

            entry.Phones.UnionWith(formatedNumbers);
            return notNameAlredyExist;
        }

        public int ChangePhone(string currentNumber, string newNumber)
        {
            currentNumber = this.formater.Format(currentNumber);
            newNumber = this.formater.Format(newNumber);

            var found = this.multidict[currentNumber].ToList();
            foreach (var entry in found)
            {
                entry.Phones.Remove(currentNumber);
                this.multidict.Remove(currentNumber, entry);

                entry.Phones.Add(newNumber);
                this.multidict.Add(newNumber, entry);
            }

            return found.Count;
        }

        public IEnumerable<PhonebookEntry> ListEntries(int start, int count)
        {
            if (start < 0 || start + count > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            var list = new PhonebookEntry[count];

            for (var i = start; i <= start + count - 1; i++)
            {
                var entry = this.sorted[i];
                list[i - start] = entry;
            }

            return list;
        }
    }
}