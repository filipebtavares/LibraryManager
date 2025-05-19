
using LibraryManager.Api.Model;
using LibraryManager.Api.Persistence;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManager.Api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly LibraryManagerDb _context;

        public BookController(LibraryManagerDb context)
        {
            _context = context;
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
            if (string.IsNullOrWhiteSpace(createBook.Synopsis))
            {
                return BadRequest("O Sinopse não pode ser em branco.");
            }

            if (string.IsNullOrWhiteSpace(createBook.Author))
            {
                return BadRequest("O Author não pode ser em branco.");
            }

            if (string.IsNullOrWhiteSpace(createBook.Title))
            {
                return BadRequest("O title não pode ser em branco.");
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
