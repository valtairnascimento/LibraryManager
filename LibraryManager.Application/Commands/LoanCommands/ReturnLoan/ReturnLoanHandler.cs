using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.ReturnLoan
{
    public class ReturnLoanHandler : IRequestHandler<ReturnLoanCommand, ResultViewModel>
    {
        private readonly LibraryManagerDbContext _context;
        public ReturnLoanHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = _context.Loans.Find(request.Id);

            if (loan is null)
            {
                return ResultViewModel<string>.Error("Empréstimo não encontrado.");
            }

            if (request.ReturnDate < loan.LoanDate)
            {
                return ResultViewModel<string>.Error("A data de devolucao nao pode ser menor que a data de emprestimo");
            }

            loan.ReturnDate = request.ReturnDate;
            await _context.SaveChangesAsync();

            var loanDays = 3;
            var addDate = loan.LoanDate.AddDays(loanDays);
            var delayDays = (request.ReturnDate - addDate).Days;

            if (delayDays > 0)
            {
                return ResultViewModel<string>.Success($"Atraso de {delayDays} dias na devolucao do emprestimo");
            }

            return ResultViewModel<string>.Success("Livro devolvido no prazo correto");
        }
    }
}
