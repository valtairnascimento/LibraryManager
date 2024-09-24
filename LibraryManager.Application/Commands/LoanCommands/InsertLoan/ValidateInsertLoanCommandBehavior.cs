using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.InsertLoan
{
    public class ValidateInsertLoanCommandBehavior : IPipelineBehavior<InsertLoanCommand, ResultViewModel<int>>
    {
        private readonly LibraryManagerDbContext _context;
        public ValidateInsertLoanCommandBehavior(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertLoanCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var userExists = _context.Users.Any(u => u.Id == request.IdUser);
            var bookExists = _context.Books.Any(b => b.Id == request.IdBook);


            if (!userExists || !bookExists) 
            {
               return ResultViewModel<int>.Error("Usuario ou Livro invalidos.");
            }

            return await next();
        }
    }
}
