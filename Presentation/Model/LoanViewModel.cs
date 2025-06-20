using LibraryManager.Api.Domain.Entity;
using LibraryManager.Api.Domain.Enum;

namespace LibraryManager.Api.Presentation.Model
{
    public class LoanViewModel
    {
        public int IdUser { get; private set; }
        public string UserName { get; private set; }
        public int IdBook { get; private set; }
        public string NameBook { get; private set; }
        public StatusLoanEnum Status { get; private set; }
        public List<User> Users { get; private set; }
        public DateTime LoanDate { get; private set; }

        public LoanViewModel(int idUser, string userName, int idBook, string nameBook, 
            StatusLoanEnum status, List<User> users, DateTime loanDate)
        {
            IdUser = idUser;
            UserName = userName;
            IdBook = idBook;
            NameBook = nameBook;
            Status = status;
            Users = users;
            LoanDate = loanDate;
        }

        public static LoanViewModel FromEntity(Loan loan)
            => new(loan.IdUser, loan.User.Name, loan.IdBook, loan.Book.Title, loan.StatusLoan, loan.Users,
                loan.LoanDate);
    }
}
