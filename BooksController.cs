using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;

// internal can be accessed by files in the same project
// you can't create instances of static classes
internal static class BooksController
{
   private static List<string> _books = new()
   {
    "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
   };

   internal static void ViewBooks()
   {
      AnsiConsole.MarkupLine("[yellow]List of books:[/]");

      foreach (var book in _books)
      {
         AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
      }

      AnsiConsole.MarkupLine("Press any key to continue");
      Console.ReadKey();
   }

   internal static void AddBook()
   {
      var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

      if (_books.Contains(title))
      {
         AnsiConsole.MarkupLine("[red]This book already exists[/]");
      }
      else
      {
         _books.Add(title);
         AnsiConsole.MarkupLine("[green]Book added successfully[/]");
      }

      AnsiConsole.MarkupLine("Press any key to continue");
      Console.ReadKey();
   }

   internal static void DeleteBook()
   {
      if (_books.Count == 0)
      {
         AnsiConsole.MarkupLine("[red]No books available to delete");
         Console.ReadKey();
         return;
      }

      var bookToDelete = AnsiConsole.Prompt(
         new SelectionPrompt<string>()
            .Title("Select a [red]book[/] to delete:")
            .AddChoices(_books));

      if (_books.Remove(bookToDelete))
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