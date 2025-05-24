using System.ComponentModel.DataAnnotations;
using LibraryManager.Api.Domain.Entity;

namespace LibraryManager.Api.Presentation.Model
{
    public class CreateBookModel
    {

        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Author { get; set; }
        public int YearOfPublication { get; set; }


        public Book ToEntity()
            => new Book(Title, Author, YearOfPublication, Synopsis);
    }
}
