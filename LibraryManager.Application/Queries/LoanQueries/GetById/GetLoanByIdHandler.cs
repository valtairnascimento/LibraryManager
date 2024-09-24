using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetById
{
    public partial class GetLoanByIdQuery
    {
        public class GetLoanByIdHandler : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
        {
            private readonly ILoanRepository _repository;
            public GetLoanByIdHandler(ILoanRepository repository)
            {
                _repository = repository;
            }
            public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
            {
                var loan = await _repository.GetDetailsById(request.Id);    

                if (loan is null)
                {
                    return ResultViewModel<LoanViewModel>.Error("Emprestimo nao existe");
                }

                var model = LoanViewModel.FromEntity(loan);

                return ResultViewModel<LoanViewModel>.Success(model);
            }
        }
    }
}
