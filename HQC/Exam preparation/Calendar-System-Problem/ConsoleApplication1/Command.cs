namespace CalendarSystem.ConsoleClient
{
    using System;

    public struct Command
    {
        private string x;

        public string CommandName;

        public string[] paramms { get; set; }

        public static Command Parse(string c)
        {
            var j = c.IndexOf(' ');
            if (j == -1)
            {
                throw new Exception("Invalid command: " + c);
            }

            var nam = c.Substring(0, j);
            var arg = c.Substring(j + 1);

            var commandArguments = arg.Split('|');
            for (var i = 0; i < commandArguments.Length; i++)
            {
                arg = commandArguments[i];
                commandArguments[i] = arg.Trim();
            }

            var command = new Command { CommandName = nam, paramms = commandArguments };

            return command;
        }
    }
}