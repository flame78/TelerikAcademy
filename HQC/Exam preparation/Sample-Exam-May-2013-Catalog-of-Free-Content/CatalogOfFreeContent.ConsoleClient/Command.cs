namespace CatalogOfFreeContent.ConsoleClient
{
    using System;
    using System.Linq;

    using CatalogOfFreeContent.ConsoleClient.Contracts;
    using CatalogOfFreeContent.Lib.Enumerations;

    public class Command : ICommand
    {
        private const int CommandSeparatorLength = 2;

        private const char CommandEnd = ':';

        private const char ParametersSeparator = ';';

        private int commandNameLength;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public CommandType ParseCommandType(string commandName)
        {
            CommandType type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException();
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    {
                        type = CommandType.AddBook;
                    }

                    break;

                case "Add movie":
                    {
                        type = CommandType.AddMovie;
                    }

                    break;

                case "Add song":
                    {
                        type = CommandType.AddSong;
                    }

                    break;

                case "Add application":
                    {
                        type = CommandType.AddApplication;
                    }

                    break;

                case "Update":
                    {
                        type = CommandType.Update;
                    }

                    break;

                case "Find":
                    {
                        type = CommandType.Find;
                    }

                    break;

                default:
                    {
                        if (commandName.ToLower().Contains("book") || commandName.ToLower().Contains("movie")
                            || commandName.ToLower().Contains("song") || commandName.ToLower().Contains("application"))
                        {
                            throw new InsufficientExecutionStackException();
                        }

                        if (commandName.ToLower().Contains("find") || commandName.ToLower().Contains("update"))
                        {
                            throw new InvalidProgramException();
                        }

                        throw new MissingFieldException("Invalid command name!");
                    }
            }

            return type;
        }

        public string ParseName()
        {
            var name = this.OriginalForm.Substring(0, this.commandNameLength);
            return name;
        }

        public string[] ParseParameters()
        {
            var paramsLength = this.OriginalForm.Length - (this.commandNameLength + CommandSeparatorLength);

            var paramsOriginalForm = this.OriginalForm.Substring(
                this.commandNameLength + CommandSeparatorLength, 
                paramsLength);

            var parameters = paramsOriginalForm.Split(
                new[] { ParametersSeparator }, 
                StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            var endIndex = this.OriginalForm.IndexOf(CommandEnd);

            return endIndex;
        }

        public override string ToString()
        {
            var toString = string.Empty + this.Name + " ";

            foreach (var param in this.Parameters)
            {
                toString += param + " ";
            }

            return toString;
        }

        private void TrimParams()
        {
            for (var i = 0;; i++)
            {
                if (!(i < this.Parameters.Length))
                {
                    break;
                }

                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        private void Parse()
        {
            this.commandNameLength = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }
    }
}