namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private readonly string name;

        public PhonebookEntry(string name, SortedSet<string> phones)
        {
            this.name = name;
            this.Phones = phones;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        internal SortedSet<string> Phones { get; set; }

        public int CompareTo(PhonebookEntry other)
        {
            return this.name.ToLowerInvariant().CompareTo(other.name.ToLowerInvariant());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Clear();
            sb.Append('[');

            sb.Append(this.Name);
            var flag = true;
            foreach (var phone in this.Phones)
            {
                if (flag)
                {
                    sb.Append(": ");
                    flag = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(phone);
            }

            sb.Append(']');
            return sb.ToString();
        }
    }
}