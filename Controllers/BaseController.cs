using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem.Controllers;

public interface IBaseController
{
    void ViewItems();
    void AddItem();
    void DeleteItem();
}

internal abstract class BaseController
{
    protected void DisplayMessage(string message, string colour = "yellow")
    {
        AnsiConsole.MarkupLine($"[{colour}]{message}[/]");
    }

    protected bool ConfirmDeletion(string itemName)
    {
        var confirm = AnsiConsole.Confirm($"Are you sure you want to delete {itemName}");
        return confirm;
    }
}