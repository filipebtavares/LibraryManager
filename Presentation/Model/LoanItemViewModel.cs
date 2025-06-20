using LibraryManager.Api.Domain.Entity;
using LibraryManager.Api.Domain.Enum;

namespace LibraryManager.Api.Presentation.Model
{
    public class LoanItemViewModel
    {
        public int IdUser { get; private set; }
        public string UserName { get; private set; }
        public int IdBook { get; private set; }
        public string NameBook { get; private set; }
        public StatusLoanEnum Status { get; private set; }

        public LoanItemViewModel(int idUser, string userName, int idBook, string nameBook, StatusLoanEnum status)
        {
            IdUser = idUser;
            UserName = userName;
            IdBook = idBook;
            NameBook = nameBook;
            Status = status;
        }

        public static LoanItemViewModel FromEntity(Loan loan)
            => new(loan.IdUser, loan.User.Name, loan.IdBook, loan.Book.Title, loan.StatusLoan);
    }
}
