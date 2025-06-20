using LibraryManager.Api.Infrastructure.Persistence;
using LibraryManager.Api.Presentation.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Api.Presentation.Controller
{
    [Route("api/loan")]
    [ApiController]
    public class LoanController : ControllerBase
    {

        private readonly LibraryManagerDb _context;

        public LoanController(LibraryManagerDb context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostLoan(CreateLoanModel loanModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loan = loanModel.FromEntityLoan();

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, loanModel);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resultAllLoan = _context.Loans.ToList();
            return Ok(resultAllLoan);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoanById(int id)
        {
            var loanId = _context.Loans.SingleOrDefault(i => i.Id == id);
            return Ok(loanId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoan(int id)
        {
            if (!_context.Loans.Any(i => i.Id == id))
            {
                return BadRequest("O Id informado não foi encontrado");
            }
            return NoContent();
        }

    }
}
