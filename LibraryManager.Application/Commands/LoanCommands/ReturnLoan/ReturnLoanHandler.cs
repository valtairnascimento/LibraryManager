using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.ReturnLoan
{
    public class ReturnLoanHandler : IRequestHandler<ReturnLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _repository;
        public ReturnLoanHandler(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetById(request.Id);

            if (loan is null)
            {
                return ResultViewModel<string>.Error("Empréstimo não encontrado.");
            }

            if (request.ReturnDate < loan.LoanDate)
            {
                return ResultViewModel<string>.Error("A data de devolucao nao pode ser menor que a data de emprestimo");
            }

            loan.ReturnDate = request.ReturnDate;
            await _repository.Update(loan);

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
