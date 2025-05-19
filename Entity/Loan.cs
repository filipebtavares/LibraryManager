using System.ComponentModel.DataAnnotations;
using LibraryManager.Api.Enum;

namespace LibraryManager.Api.Entity
{
    public class Loan : Base
    {
       
        public int IdUser { get; private set; }
        public User  User { get; private set; }

        public int IdBook { get; private set; }
        public Book Book { get; private set; }

        public DateTime LoanDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public List<User> Users { get; private set; }

   
        public StatusLoanEnum StatusLoan { get; private set; }
        public int QuantityDay { get; private set; }

        public Loan()
        {
        }

        public Loan(int idUser, int idBook,      int quantityday)
            : base()
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = DateTime.Now;
            StatusLoan = StatusLoanEnum.InProgress;
            QuantityDay = quantityday;
           


            Users = [];
        }

        public decimal ValueLoan()
        {
            return (decimal)(0.5 * QuantityDay);
        }

        public void ReturnLoan()
        {
            ReturnDate = DateTime.Now;
            StatusLoan = StatusLoanEnum.Returned;
        }

        public int DaysOverdue()
        {
            if (!ReturnDate.HasValue)
            {
                return 0;


            }

            var dueDate = LoanDate.AddDays(QuantityDay);
            var daysLate = (ReturnDate.Value - dueDate).Days;

            return daysLate > 0 ? daysLate : 0;
        }
    }
}
