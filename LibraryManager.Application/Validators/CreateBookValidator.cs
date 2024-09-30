using FluentValidation;
using LibraryManager.Application.Commands.BookCommands.InsertBook;

namespace LibraryManager.Application.Validators
{

    public class CreateBookValidator : AbstractValidator<InsertBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(b => b.Title).NotEmpty()
                .MaximumLength(50).MinimumLength(12);

            RuleFor(b => b.Author).NotEmpty()
                .MinimumLength(4).MaximumLength(50);

            RuleFor(b => b.PublicationYear)
                 .Must(publicateDate => publicateDate.Year <= DateTime.Now.Year).WithMessage("O ano de publicação não pode ser maior que o ano atual.");

            RuleFor(b => b.ISBN).MaximumLength(13);
        }    
                      
    }
}
