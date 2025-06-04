using System.ComponentModel.DataAnnotations;
using LibraryManager.Api.Domain.Entity;


namespace LibraryManager.Api.Presentation.Model
{
    public class CreateLoanModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public int QuantityDay { get; set; }


        public Loan FromEntityLoan()
            => new Loan(IdUser, IdBook, QuantityDay);
    }
}
