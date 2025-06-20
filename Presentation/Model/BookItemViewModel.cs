using LibraryManager.Api.Domain.Entity;

namespace LibraryManager.Api.Presentation.Model
{
    public class BookItemViewModel
    {
        public string  Author { get; private set; }
        public string Title { get; private set; }
        public string Synopsis { get; private set; }
        public int YearOfPublication { get; private set; }

        public BookItemViewModel(string author, string title, string synopsis, int yearOfPublication)
        {
            Author = author;
            Title = title;
            Synopsis = synopsis;
            YearOfPublication = yearOfPublication;
        }

        public static BookItemViewModel FromEntity(Book book)
            => new(book.Author, book.Title, book.Synopsis, book.YearOfPublication);
    }
}
