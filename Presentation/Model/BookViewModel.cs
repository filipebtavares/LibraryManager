using LibraryManager.Api.Domain.Entity;

namespace LibraryManager.Api.Presentation.Model
{
    public class BookViewModel
    {
        public string Title { get; private set; }
        public string Synopsis { get; private set; }
        public string Author { get; private set; }
        public int Isbn { get; private set; }
        public int YearOfPublication { get; private set; }
        public List<Loan> Loans { get; private set; }

        public BookViewModel(string title, string synopsis, string author, int isbn, int yearOfPublication, List<Loan> loans)
        {
            Title = title;
            Synopsis = synopsis;
            Author = author;
            Isbn = isbn;
            YearOfPublication = yearOfPublication;
            Loans = loans;
        }


        public static BookViewModel FromEntity(Book book)
            => new(book.Title, book.Synopsis, book.Author, book.Isbn, book.YearOfPublication, book.Loans);
    }
}
