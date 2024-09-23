using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Commands.LoanCommands.DeleteLoan
{
    public class DeleteLoanHandler : IRequestHandler<DeleteLoanCommand, ResultViewModel>
    {
        private readonly LibraryManagerDbContext _context;
        public DeleteLoanHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.SingleOrDefaultAsync(l => l.Id == request.Id);

            if (loan == null)
            {
                return ResultViewModel<LoanViewModel>.Error("Emprestimo nao existe");
            }

            loan.SetAsDeleted();
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
