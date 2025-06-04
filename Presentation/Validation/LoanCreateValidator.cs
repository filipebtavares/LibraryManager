using FluentValidation;
using LibraryManager.Api.Domain.Entity;
using LibraryManager.Api.Presentation.Model;

namespace LibraryManager.Api.Presentation.Validation
{
    public class LoanCreateValidator : AbstractValidator<CreateLoanModel>
    {
        public LoanCreateValidator()
        {
            RuleFor(loan => loan.IdBook)
                .GreaterThan(0).WithMessage("O Id deve ser valido.")
                .NotNull().WithMessage("O id do livro é obrigatório");

            RuleFor(loan => loan.IdUser)
               .GreaterThan(0).WithMessage("O Id deve ser valido.")
               .NotNull().WithMessage("O id do usuário é obrigatório");

            RuleFor(loan => loan.QuantityDay)
                .LessThanOrEqualTo(30).WithMessage("A quantidade de dias não pode ultrapassar 30 dias.")
                .NotNull().WithMessage("A quantidade de dias de emprestimo é obrigatório");

        }
    }
}
