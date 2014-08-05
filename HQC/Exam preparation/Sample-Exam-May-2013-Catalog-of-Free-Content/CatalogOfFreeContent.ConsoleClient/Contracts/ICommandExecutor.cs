namespace CatalogOfFreeContent.ConsoleClient.Contracts
{
    using System.Text;

    public interface ICommandExecutor
    {
        StringBuilder ExecuteCommand(ICommand command);
    }
}