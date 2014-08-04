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

        public PhonebookRepository(IEnumerable<PhonebookEntry> entries)
            : this()
        {
            foreach (var entry in entries)
            {
                this.AddPhone(entry.Name, entry.Phones);
            }
        }

        public PhonebookRepository()
        {
            this.dict = new Dictionary<string, PhonebookEntry>();
            this.multidict = new MultiDictionary<string, PhonebookEntry>(false);
            this.sorted = new OrderedSet<PhonebookEntry>();
        }

        public bool AddPhone(string name, IEnumerable<string> numbers)
        {
            var nameInLowerInvariant = name.ToLowerInvariant();

            PhonebookEntry entry;

            var notNameAlredyExist = !this.dict.TryGetValue(nameInLowerInvariant, out entry);

            if (notNameAlredyExist)
            {
                entry = new PhonebookEntry(name, new SortedSet<string>());
                this.dict.Add(nameInLowerInvariant, entry);
                this.sorted.Add(entry);
            }

            foreach (var number in numbers)
            {
                this.multidict.Add(number, entry);
            }

            entry.Phones.UnionWith(numbers);
            return notNameAlredyExist;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.Phones.Remove(oldent);
                this.multidict.Remove(oldent, entry);

                entry.Phones.Add(newent);
                this.multidict.Add(newent, entry);
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