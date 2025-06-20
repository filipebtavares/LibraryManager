using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Api.Domain.Entity
{
    public class Book : Base
    {

        public string Title { get; private set; }
        public string Synopsis { get; private set; }
        public string Author { get; private set; }
        public int Isbn { get; private set; }
        public int YearOfPublication { get; private set; }
        public List<Loan> Loans { get; private set; }


        public Book()
        {
        }
        public Book(string title, string author, int yearOfPublication, string synopsis)
            : base()
        {
            Title = title;
            Author = author;
            YearOfPublication = yearOfPublication;
            Synopsis = synopsis;


            Loans = [];

        }

    }
}
