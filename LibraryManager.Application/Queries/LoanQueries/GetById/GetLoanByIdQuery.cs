using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetById
{
    public partial class GetLoanByIdQuery :IRequest<ResultViewModel<LoanViewModel>>
    {
        public GetLoanByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
