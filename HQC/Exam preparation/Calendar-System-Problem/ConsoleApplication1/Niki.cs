namespace CalendarSystem.ConsoleClient
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Niki
    {
        private readonly IEventsManager em;

        public Niki(IEventsManager em)
        {
            int b;
            this.em = em;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.em;
            }
        }

        public string ProcessCommand(Command com)
        {
            // First command
            if ((com.CommandName == "AddEvent") && (com.paramms.Length == 2))
            {
                var date = DateTime.ParseExact(com.paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var e = new Ev { d = date, Title = com.paramms[1], Location = null, };

                this.em.AddEvent(e);

                return "Event added";
            }
            if ((com.CommandName == "AddEvent") && (com.paramms.Length == 3))
            {
                var date = DateTime.ParseExact(com.paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var e = new Ev { d = date, Title = com.paramms[1], Location = com.paramms[2], };

                this.em.AddEvent(e);

                return "Event added";
                return string.Empty;
            }
            // Second command
            if ((com.CommandName == "DeleteEvents") && (com.paramms.Length == 1))
            {
                var c = this.em.DeleteEventsByTitle(com.paramms[0]);

                if (c == 0)
                {
                    return "No events found.";
                }

                return c + " events deleted";
            }
            // Third command
            if ((com.CommandName == "ListEvents") && (com.paramms.Length == 2))
            {
                var d = DateTime.ParseExact(com.paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var c = int.Parse(com.paramms[1]);
                var events = this.em.ListEvents(d, c).ToList();
                var sb = new StringBuilder();

                if (!events.Any())
                {
                    return "No events found";
                }

                foreach (var e in events)
                {
                    sb.AppendLine(e.ToString());
                }

                return sb.ToString().Trim();
            }
            throw new Exception("WTF " + com.CommandName + " is?");
        }
    }
}