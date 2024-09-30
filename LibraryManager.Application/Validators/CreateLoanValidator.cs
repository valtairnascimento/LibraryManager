using FluentValidation;
using LibraryManager.Application.Commands.LoanCommands.InsertLoan;

namespace LibraryManager.Application.Validators
{
    public class CreateLoanValidator :AbstractValidator<InsertLoanCommand>
    {
        public CreateLoanValidator()
        {
            RuleFor(l => l.IdUser).NotEmpty().NotNull().WithMessage("Obrigatorio informar o Id do usuario");

            RuleFor(l => l.IdBook).NotEmpty().NotNull().WithMessage("Obrigatorio informar o Id do Livro");

            RuleFor(l => l.LoanDate).NotEmpty();
        }
    }
}
