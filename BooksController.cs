using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;

// internal can be accessed by files in the same project
internal class BooksController
{
   internal void ViewBooks()
   {
      AnsiConsole.MarkupLine("[yellow]List of books:[/]");

      foreach (var book in MockDatabase.Books)
      {
         AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
      }

      AnsiConsole.MarkupLine("Press any key to continue");
      Console.ReadKey();
   }

   internal void AddBook()
   {
      var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

      if (MockDatabase.Books.Contains(title))
      {
         AnsiConsole.MarkupLine("[red]This book already exists[/]");
      }
      else
      {
         MockDatabase.Books.Add(title);
         AnsiConsole.MarkupLine("[green]Book added successfully[/]");
      }

      AnsiConsole.MarkupLine("Press any key to continue");
      Console.ReadKey();
   }

   internal void DeleteBook()
   {
      if (MockDatabase.Books.Count == 0)
      {
         AnsiConsole.MarkupLine("[red]No books available to delete");
         Console.ReadKey();
         return;
      }

      var bookToDelete = AnsiConsole.Prompt(
         new SelectionPrompt<string>()
            .Title("Select a [red]book[/] to delete:")
            .AddChoices(MockDatabase.Books));

      if (MockDatabase.Books.Remove(bookToDelete))
      {
         AnsiConsole.MarkupLine("[red]Book deleted successfully[/]");
      }
      else
      {
         AnsiConsole.MarkupLine("[red]Book not found[/]");
      }

      AnsiConsole.MarkupLine("Press any key to continue");
      Console.ReadKey();
   }
}