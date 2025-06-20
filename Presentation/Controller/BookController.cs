using FluentValidation;
using LibraryManager.Api.Application.Service;
using LibraryManager.Api.Infrastructure.Persistence;
using LibraryManager.Api.Presentation.Model;
using LibraryManager.Api.Presentation.Validation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManager.Api.Presentation.Controller
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly LibraryManagerDb _context;
        private readonly IBookService _service;
     

        public BookController(LibraryManagerDb context, IValidator<CreateUserModelValidator> validator, IBookService service)
        {
            _context = context;
            _service = service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var resultAll = _context.Books.ToList();
            return Ok(resultAll);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var booksId = _context.Books.SingleOrDefault(i => i.Id == id);
            return Ok(booksId);
        }



        [HttpPost]
        public IActionResult Post(CreateBookModel createBook)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = createBook.ToEntity();

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, createBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (!_context.Books.Any(i => i.Id == id))
            {
                return BadRequest("O Id informado não foi encontrado");
            }
            return NoContent();
        }
    }
}
