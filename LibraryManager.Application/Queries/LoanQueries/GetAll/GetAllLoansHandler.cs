using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Queries.LoanQueries.GetAll
{
    public class GetAllLoansHandler : IRequestHandler<GetAllLoansQuery, ResultViewModel<List<LoanViewModel>>>
    {
        private readonly LibraryManagerDbContext _context;
        public GetAllLoansHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans
                    .Include(l => l.User)
                    .Include(l => l.Book)
                    .Where(l => !l.IsDeleted)
                    .ToListAsync();

            var model = loan.Select(LoanViewModel.FromEntity).ToList();

            return ResultViewModel<List<LoanViewModel>>.Success(model);
        }
    }
    
}
