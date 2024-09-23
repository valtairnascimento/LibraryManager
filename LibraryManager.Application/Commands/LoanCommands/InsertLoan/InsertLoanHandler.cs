using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.InsertLoan
{
    public class InsertLoanHandler : IRequestHandler<InsertLoanCommand, ResultViewModel<int>>
    {
        private readonly LibraryManagerDbContext _context;
        public InsertLoanHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = request.ToEntity();

            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(loan.Id);
        }
    }
}
