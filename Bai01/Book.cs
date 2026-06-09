namespace Bai01;

class Book : IComparable<Book>//imple interface IComparable<Book> để sắp xếp sách theo năm xuất bản
{
    public string? Title;
    public string? Author;
    public string? ISBN;
    public int YearPublished;


    //contructor có tham số
    public string GetBookTitle()
    {
        return Title ?? "Unknown Title";
    }
    public string GetBookAuthor()
    {
        return Author ?? "Unknown Author";
    }
    public string GetBookISBN()
    {
        return ISBN ?? "Unknown ISBN";
    }
    public int GetBookYearPublished()
    {
        return YearPublished;
    }
    public void SetBook(string title, string author, string isbn, int yearPublished)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        YearPublished = validationYear(yearPublished);
    }
    //contructor không tham số
    public Book()
    {
        Title = "Unknown Title";
        Author = "Unknown Author";
        ISBN = "Unknown ISBN";
        YearPublished = 0;
    }
    public void DisplayBookInfo()
    {
        Console.WriteLine($"Title: {GetBookTitle()}");
        Console.WriteLine($"Author: {GetBookAuthor()}");
        Console.WriteLine($"ISBN: {GetBookISBN()}");
        Console.WriteLine($"Year Published: {GetBookYearPublished()}");
    }

    int validationYear(int year)
    {
        try
        {
            if (year < 1000 || year > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Nam phai tu 1000 cho den hien tai.");
            }
            return year;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return -1; 
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is Book other)
        {
            if (other.ISBN == null || ISBN == null)
                return false;
            return ISBN == other.ISBN;
        }
        return false;
    }
    //A1. Implement IComparable<Book> để sắp xếp sách theo năm xuất bản
    public int CompareTo(Book other)
    {
        if (other == null) return 1; // Sách hiện tại lớn hơn null
        return YearPublished.CompareTo(other.YearPublished);// So sánh năm xuất bản của sách hiện tại với sách khác
    }
    //A2. Viết method GetBooksAfterYear(int year) (không dùng LINQ)
    public void GetBooksAfterYear(Book[] books, int year)
    {
        Console.WriteLine($"Books published after {year}:");
        foreach (Book book in books)
        {
            if (book.YearPublished > year)
            {
                book.DisplayBookInfo();
                Console.WriteLine();
            }
        }
    }
    //A3. Đếm số sách theo tác giả và lưu vào Dictionary<string,int>
    Dictionary<string, int> CountBooksByAuthor(Book[] books)
    {
        Dictionary<string, int> authorCounts = new Dictionary<string, int>();
        foreach (Book book in books)
        {
            if (book.Author != null)
            {
                if (authorCounts.ContainsKey(book.Author))
                {
                    authorCounts[book.Author]++;
                }
                else
                {
                    authorCounts[book.Author] = 1;
                }
            }
        }
        return authorCounts;
    }
}
