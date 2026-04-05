using System;
struct BookCode
{
    public string Section;
    public int Number;
    public BookCode(string section, int number)
    {
        Section = section;
        Number = number;
    }
        public override string ToString()
    {
        return Section + "-" + Number;
    }
}
record Book
{
    public string Title { get; init; }
    public string Author { get; init; }
    public BookCode BookCode { get; init; }
    public DateTime CreatedAt { get; init; }
}
interface IBorrowable
{
    void Borrow();
    void Return();
}
class LibraryBook : IBorrowable
{
    public Book Book { get; set; }

    private bool IsBorrowed = false;

    public void Borrow()
    {
        if (IsBorrowed)
        {
            Console.WriteLine("Already borrowed");
        }
        else
        {
            IsBorrowed = true;
            Console.WriteLine("Book borrowed");
        }
    }
    public void Return()
    {
        if (!IsBorrowed)
        {
            Console.WriteLine("Not borrowed");
        }
        else
        {
            IsBorrowed = false;
            Console.WriteLine("Book returned");
        }
    }
}
static class DateHelper
{
    public static bool IsNew(this DateTime date)
    {
        return (DateTime.Now - date).TotalDays <= 7;
    }
}
class Program
{
    static void Main()
    {
        Book book1 = new Book
        {
            Title = "C# Basics",
            Author = "Ali",
            BookCode = new BookCode("A", 15),
            CreatedAt = DateTime.Now.AddDays(-2)
        };

        Book book2 = new Book
        {
            Title = "Programming",
            Author = "Veli",
            BookCode = new BookCode("B", 10),
            CreatedAt = DateTime.Now.AddDays(-10)
        };

        LibraryBook lib1 = new LibraryBook();
        LibraryBook lib2 = new LibraryBook();
        lib2.Book = book2;
        lib1.Borrow();
        lib1.Borrow();
        lib1.Return();
        lib1.Return();
        Console.WriteLine();
        Console.WriteLine(book1.Title + " new? " + book1.CreatedAt.IsNew());
        Console.WriteLine(book2.Title + " new? " + book2.CreatedAt.IsNew());
        Console.WriteLine();
        Console.WriteLine("Code1: " + book1.BookCode);
        Console.WriteLine("Code2: " + book2.BookCode);
    }
}