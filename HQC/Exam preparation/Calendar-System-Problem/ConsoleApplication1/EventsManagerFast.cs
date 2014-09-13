namespace CalendarSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, Ev> t = new MultiDictionary<string, Ev>(true);

        private readonly OrderedMultiDictionary<DateTime, Ev> a = new OrderedMultiDictionary<DateTime, Ev>(true);

        public void AddEvent(Ev e)
        {
            var eventTitleLowerCase = e.Title.ToLowerInvariant();
            this.t.Add(eventTitleLowerCase, e);
            this.a.Add(e.d, e);
        }

        public int DeleteEventsByTitle(string t)
        {
            var lc = t.ToLowerInvariant();
            var del = this.t[lc;
            var countx = del.Count;

            foreach (var e in del)
            {
                this.a.Remove(e.d, e);
            }

            this.t.Remove(lc);

            return countx;
        }

        public IEnumerable<Ev> ListEvents(DateTime d, int c)
        {
            var da = from e in this.a.RangeFrom(d, true).Values select e;
            var events = da.Take(c);
            return events;
        }
    }
}