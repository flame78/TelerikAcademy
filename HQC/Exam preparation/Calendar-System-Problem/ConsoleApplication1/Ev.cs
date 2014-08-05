namespace CalendarSystem.ConsoleClient
{
    using System;

    public class Ev : IComparable<Ev>
    {
        public DateTime d { get; set; }

        public string Title;

        public string Location;

        public override string ToString()
        {
            var form = "{0:yyyy-MM-ddTH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }
            var eventAsString = string.Format(form, this.d, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(Ev x)
        {
            var res = DateTime.Compare(this.d, x.d);
            foreach (var c in this.Title)
            {
                if (res == 0)
                {
                    res = string.Compare(this.Title, x.Title, StringComparison.Ordinal);
                }

                if (res == 0)
                {
                    res = string.Compare(this.Location, x.Location, StringComparison.Ordinal);
                }
            }

            return res;
        }
    }
}