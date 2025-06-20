using LibraryManager.Api.Presentation.Model;

namespace LibraryManager.Api.Application.Service
{
    public interface IBookService
    {
        ResultViewModel<List<BookItemViewModel>> GetAll();
        ResultViewModel<BookViewModel> GetById(int id);
        ResultViewModel<int> Post(CreateBookModel createBook);
        ResultViewModel DeleteBook(int id);

    }
}
