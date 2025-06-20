using LibraryManager.Api.Infrastructure.Persistence;
using LibraryManager.Api.Presentation.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Api.Application.Service
{
    public class BookService : IBookService
    {
        private readonly LibraryManagerDb _dbContext;

        public BookService(LibraryManagerDb dbContext)
        {
            _dbContext = dbContext;
        }

        public ResultViewModel<List<BookItemViewModel>> GetAll()
        {
            var books = _dbContext.Books
                .Include(p => p.Loans);

            var model = books.Select(BookItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookItemViewModel>>.Success(model);
        }

        public ResultViewModel<BookViewModel> GetById(int id)
        {
            var books = _dbContext.Books
                .Include(p => p.Loans)
                .SingleOrDefault(p => p.Id == id);

            if(books is null)
            {
                return ResultViewModel<BookViewModel>.Error("O livro não existe.");
            }

            var model = BookViewModel.FromEntity(books);

            return ResultViewModel<BookViewModel>.Success(model);
        }

        public ResultViewModel<int> Post(CreateBookModel createBook)
        {
            var book = createBook.ToEntity();

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return ResultViewModel<int>.Success(book.Id);
        }

        public ResultViewModel DeleteBook(int id)
        {
            var Book = _dbContext.Books.SingleOrDefault(p => p.Id == id);

            if (Book is null)
            {
                return ResultViewModel.Error("O projeto não foi encontrado.");
            }

            Book.SetAsDeleted();
            _dbContext.Books.Update(Book);
            _dbContext.SaveChanges();

            return ResultViewModel.Success();

        }
    }
}
