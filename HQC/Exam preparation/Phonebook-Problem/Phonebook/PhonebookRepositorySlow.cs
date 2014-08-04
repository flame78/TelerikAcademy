namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Contracts;

    public class PhonebookRepositorySlow : IPhonebookRepository
    {
        private readonly List<PhonebookEntry> entries;

        public PhonebookRepositorySlow()
            : this(new List<PhonebookEntry>())
        {
        }

        public PhonebookRepositorySlow(List<PhonebookEntry> entries)
        {
            this.entries = entries;
        }

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            var selectedEntry = from e in this.entries
                                where e.Name.ToLowerInvariant() == name.ToLowerInvariant()
                                select e;

            if (selectedEntry.Count() == 0)
            {
                var phones = new SortedSet<string>();

                foreach (var num in nums)
                {
                    phones.Add(num);
                }

                var entry = new PhonebookEntry(name, phones);

                this.entries.Add(entry);

                return true;
            }

            if (selectedEntry.Count() == 1)
            {
                var entry = selectedEntry.First();
                foreach (var num in nums)
                {
                    entry.Phones.Add(num);
                }

                return false;
            }

            throw new ArgumentException("Duplicated name in the phonebook found: " + name);
        }

        public int ChangePhone(string oldent, string newent)
        {
            var list = from phonebookEntry in this.entries
                       where phonebookEntry.Phones.Contains(oldent)
                       select phonebookEntry;

            var nums = 0;
            foreach (var entry in list)
            {
                entry.Phones.Remove(oldent);
                entry.Phones.Add(newent);
                nums++;
            }

            return nums;
        }

        public IEnumerable<PhonebookEntry> ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.entries.Sort();
            var result = new PhonebookEntry[num];
            for (var i = start; i <= start + num - 1; i++)
            {
                var entry = this.entries[i];
                result[i - start] = entry;
            }

            return result;
        }
    }
}