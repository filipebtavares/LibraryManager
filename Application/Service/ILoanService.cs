using LibraryManager.Api.Presentation.Model;

namespace LibraryManager.Api.Application.Service
{
    public interface ILoanService
    {
        ResultViewModel<int> PostLoan(CreateLoanModel loanModel);
        ResultViewModel<List<LoanItemViewModel>> GetAll();
        ResultViewModel<LoanViewModel> GetLoanById(int id);
        ResultViewModel DeleteLoan(int id);
    }
}
