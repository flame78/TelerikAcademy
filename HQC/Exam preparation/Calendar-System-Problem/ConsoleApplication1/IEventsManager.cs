namespace CalendarSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public interface IEventsManager
    {
        void AddEvent(Ev a);

        int DeleteEventsByTitle(string b);

        IEnumerable<Ev> ListEvents(DateTime c, int d);
    }
}