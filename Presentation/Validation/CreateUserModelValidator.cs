using FluentValidation;
using LibraryManager.Api.Domain.Entity;
using LibraryManager.Api.Presentation.Model;

namespace LibraryManager.Api.Presentation.Validation
{
    public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserModelValidator()
        {
            RuleFor(user => user.Name)
                .NotNull().WithMessage("O nome do usuário é obrigatorio.")
                .MaximumLength(50).WithMessage("O nome do usuario não pode conter mais qu 50 caracteres.");

            RuleFor(user => user.Email)
                .NotNull().WithMessage("O email do usuário é obrigatorio.")
                .EmailAddress().WithMessage("O email não é valido.");
              
        }
    }
}
