using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetAll
{
    public class GetAllLoansQuery :IRequest<ResultViewModel<List<LoanViewModel>>>
    {
    }
    
}
