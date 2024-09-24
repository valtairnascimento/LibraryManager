using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.InsertLoan
{
    public class InsertLoanHandler : IRequestHandler<InsertLoanCommand, ResultViewModel<int>>
    {
        private readonly ILoanRepository _repository;
        public InsertLoanHandler(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = request.ToEntity();

            await _repository.Add(loan);

            return ResultViewModel<int>.Success(loan.Id);
        }
    }
}
