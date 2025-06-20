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
            var result = _service.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }



        [HttpPost]
        public IActionResult Post(CreateBookModel createBook)
        {
            var result = _service.Post(createBook);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, createBook);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _service.DeleteBook(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
