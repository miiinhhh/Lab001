namespace Bai01;

class Program
{
    static void Main(string[] args)
    {
        Book[] books = new Book[3];//ít nhất 3 quyển sách
        books[0] = new Book();
        books[0].SetBook("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565", 1925);
        books[1] = new Book();
        books[1].SetBook("To Kill a Mockingbird", "Harper Lee", "978-0061120084", 1960);
        books[2] = new Book();
        books[2].SetBook("1984", "George Orwell", "978-0451524935", 1948);
        // books[3] = new Book();
        // books[3].SetBook("Pride and Prejudice", "Jane Austen", "978-1503290563", 1813);
        books[0].CompareTo(books[1]);//so sánh sách đầu tiên với sách thứ hai
        
        foreach (Book book in books)
        {
            book.DisplayBookInfo();
            Console.WriteLine();
        }
    }
}
