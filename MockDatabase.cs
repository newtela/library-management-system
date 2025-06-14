namespace TCSA.OOP.LibraryManagementSystem;

// you can't create instances of static classes
// anything marked as static lives for the entire lifecycle of the app
public static class MockDatabase
{
    internal static List<string> Books = new()
    {
        "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye",
        "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm",
        "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist",
        "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
    };
}