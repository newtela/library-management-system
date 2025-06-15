using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem;

internal class Book : LibraryItem
{
    internal string Author { get; set; }
    internal string Category { get; set; }
    internal int Pages { get; set; }

    internal Book(int id, string name, string author, string category, string location, int pages)
        : base(id, name, location)
    {
        Author = author;
        Category = category;
        Pages = pages;
    }

    public override void DisplayDetails()
    {
        var panel = new Panel(new Markup($"[bold]Bool:[/] [cyan]{Name}[/] by [cyan]{Author}[/]") +
                              $"\n[bold]Pages:[/] {Pages}" +
                              $"\n[bold]Category:[/] [green]{Category}[/]" +
                              $"\n[bold]Location:[/] [blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
}