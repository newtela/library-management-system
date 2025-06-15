using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Controllers;

internal class MagazineController : BaseController, IBaseController
{
    public void ViewItems()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded);
        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Publisher[/]");
        table.AddColumn("[yellow]Publish Date[/]");
        table.AddColumn("[yellow]Issue Number[/]");
        table.AddColumn("[yellow]Location[/]");

        var magazines = MockDatabase.LibraryItems.OfType<Magazine>();

        foreach (var magazine in magazines)
        {
            table.AddRow(
                magazine.Id.ToString(),
                $"[cyan]{magazine.Name}[/]",
                $"[cyan]{magazine.Publisher}[/]",
                $"[cyan]{magazine.PublishDate:MMMM dd, yyyy}[/]",
                magazine.IssueNumber.ToString(),
                $"[cyan]{magazine.Location}[/]"
            );
        }

        AnsiConsole.Write(table);
        DisplayMessage("Press any key to continue");
        Console.ReadKey();
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the magazine");
        var publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the magazine");
        var publishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the magazine");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the magazine");
        var issueNumber = AnsiConsole.Ask<int>("Enter the [green]issue number[/] of the magazine");

        if (MockDatabase.LibraryItems.OfType<Magazine>()
            .Any(m => m.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            DisplayMessage("This magazine already exists", "red");
        }
        else
        {
            var newMagazine = new Magazine(MockDatabase.LibraryItems.Count + 1, title, publisher, publishDate, location,
                issueNumber);
            MockDatabase.LibraryItems.Add(newMagazine);
            DisplayMessage("Magazine added successfully", "green");
        }

        DisplayMessage("Press any key to continue");
        Console.ReadKey();
    }

    public void DeleteItem()
    {
        if (MockDatabase.LibraryItems.OfType<Magazine>().Count() == 0)
        {
            DisplayMessage("No magazines available to delete", "red");
            DisplayMessage("Press any key to continue");
            Console.ReadKey();
            return;
        }

        var magazineToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Magazine>()
                .Title("Select a [red]magazine[/] to delete:")
                .UseConverter(m => $"{m.Name} (Issue {m.IssueNumber})")
                .AddChoices(MockDatabase.LibraryItems.OfType<Magazine>())
        );

        if (ConfirmDeletion(magazineToDelete.Name))
        {
            if (MockDatabase.LibraryItems.Remove(magazineToDelete))
            {
                DisplayMessage("Magazine deleted successfully", "red");
            }
            else
            {
                DisplayMessage("Magazine not found", "red");
            }
        }
        else
        {
            DisplayMessage("Deletion cancelled", "red");
        }

        DisplayMessage("Press any key to continue");
        Console.ReadKey();
    }
}