using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Controllers;

internal class NewspaperController : IBaseController
{
    public void ViewItems()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded);
        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Publisher[/]");
        table.AddColumn("[yellow]Publish Date[/]");
        table.AddColumn("[yellow]Location[/]");

        var newspapers = MockDatabase.LibraryItems.OfType<Newspaper>();

        foreach (var newspaper in newspapers)
        {
            table.AddRow(
                newspaper.Id.ToString(),
                $"[cyan]{newspaper.Name}[/]",
                $"[cyan]{newspaper.Publisher}[/]",
                $"[cyan]{newspaper.PublishDate}[/]",
                $"[cyan]{newspaper.Location}[/]"
            );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to continue");
        Console.ReadKey();
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the newspaper");
        var publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the newspaper");
        var publishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the newspaper");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the newspaper");

        if (MockDatabase.LibraryItems.OfType<Newspaper>()
            .Any(n => n.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine("[red]This newspaper already exists[/]");
        }
        else
        {
            var newNewspaper = new Newspaper(MockDatabase.LibraryItems.Count + 1, title, publisher, publishDate,
                location);
            MockDatabase.LibraryItems.Add(newNewspaper);
            AnsiConsole.MarkupLine("[green]Newspaper added successfully[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue");
        Console.ReadKey();
    }

    public void DeleteItem()
    {
        if (MockDatabase.LibraryItems.OfType<Newspaper>().Count() == 0)
        {
            AnsiConsole.MarkupLine("[red]No newspapers available to delete[/]");
            AnsiConsole.MarkupLine("Press any key to continue");
            Console.ReadKey();
            return;
        }

        var newspaperToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Newspaper>()
                .Title("Select a [red]newspaper[/] to delete:")
                .UseConverter(n => $"{n.Name} (Published on {n.PublishDate:yyyy-MM-dd})")
                .AddChoices(MockDatabase.LibraryItems.OfType<Newspaper>())
        );

        if (MockDatabase.LibraryItems.Remove(newspaperToDelete))
        {
            AnsiConsole.MarkupLine("[red]Newspaper deleted successfully[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Newspaper not found[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue");
        Console.ReadKey();
    }
}