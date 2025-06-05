using FluentValidation;
using LibraryManager.Api.Domain.Entity;
using LibraryManager.Api.Presentation.Model;
using Microsoft.AspNetCore.Rewrite;

namespace LibraryManager.Api.Presentation.Validation
{
    public class CreateBookModelValidator : AbstractValidator<CreateBookModel>
    {
        public CreateBookModelValidator()
        {
            RuleFor(book => book.Title)
                .MinimumLength(80).WithMessage("O titulo não pode conter mais que 80 caracteries.")
                .NotNull().WithMessage("O titulo é obrigatório.");

            RuleFor(book => book.Author)
                .MaximumLength(50).WithMessage("O nome do autor não pode conter mais que 50 caracteries.")
                .NotNull().WithMessage("O nome do autor é obrigatório.");

            RuleFor(book => book.Synopsis)
               .MaximumLength(400).WithMessage("A synopsis não pode conter mais que 400 caracteries.")
               .NotNull().WithMessage("A synopsis é obrigatória.");

            RuleFor(book => book.YearOfPublication)
                 .NotNull().WithMessage("O ano de publicação é obrigatório.");
        }
    }
}
