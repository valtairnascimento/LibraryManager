using FluentValidation;
using LibraryManager.Application.Commands.UserCommands.InsertUser;

namespace LibraryManager.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<InsertUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().MinimumLength(6).MaximumLength(80);

            RuleFor(u => u.Email).NotEmpty().EmailAddress();

            RuleFor(u => u.BirthDate).NotEmpty().Must(bday => bday < DateTime.Now.AddYears(-14)).WithMessage("Apenas usuarios com mais de 14 anos");
                
        }
    }
}
