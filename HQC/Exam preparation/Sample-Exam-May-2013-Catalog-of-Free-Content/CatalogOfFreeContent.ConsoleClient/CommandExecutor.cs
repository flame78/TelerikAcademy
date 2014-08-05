namespace CatalogOfFreeContent.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Text;

    using CatalogOfFreeContent.ConsoleClient.Contracts;
    using CatalogOfFreeContent.Lib;
    using CatalogOfFreeContent.Lib.Enumerations;

    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICatalog contentCatalog;

        public CommandExecutor(ICatalog contentCatalog)
        {
            this.contentCatalog = contentCatalog;
        }

        public StringBuilder ExecuteCommand(ICommand command)
        {
            var result = new StringBuilder();

            switch (command.Type)
            {
                case CommandType.AddBook:
                    {
                        this.contentCatalog.Add(new Content(ContentType.Book, command.Parameters));
                        result.AppendLine("Book added");
                    }

                    break;

                case CommandType.AddMovie:
                    {
                        this.contentCatalog.Add(new Content(ContentType.Movie, command.Parameters));

                        result.AppendLine("Movie added");
                    }

                    break;

                case CommandType.AddSong:
                    {
                        this.contentCatalog.Add(new Content(ContentType.Song, command.Parameters));

                        result.AppendLine("Song added");
                    }

                    break;

                case CommandType.AddApplication:
                    {
                        this.contentCatalog.Add(new Content(ContentType.Application, command.Parameters));

                        result.AppendLine("Application added");
                    }

                    break;

                case CommandType.Update:
                    {
                        if (command.Parameters.Length == 2)
                        {
                        }
                        else
                        {
                            throw new FormatException("невалидни параметри!");
                        }

                        result.AppendLine(
                            string.Format("{0} items updated", this.contentCatalog.UpdateContent(command.Parameters[0], command.Parameters[1])));
                    }

                    break;

                case CommandType.Find:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            Console.WriteLine("Invalid params!");
                            throw new Exception("Invalid number of parameters!");
                        }

                        var numberOfElementsToList = int.Parse(command.Parameters[1]);

                        var foundContent = this.contentCatalog.GetListContent(command.Parameters[0], numberOfElementsToList);

                        if (foundContent.Count() == 0)
                        {
                            result.AppendLine("No items found");
                        }
                        else
                        {
                            foreach (var content in foundContent)
                            {
                                result.AppendLine(content.TextRepresentation);
                            }
                        }
                    }

                    break;

                default:
                    {
                        throw new InvalidCastException("Unknown command!");
                    }
            }

            return result;
        }
    }
}