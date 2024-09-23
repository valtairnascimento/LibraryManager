using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Queries.LoanQueries.GetById
{
    public partial class GetLoanByIdQuery
    {
        public class GetLoanByIdHandler : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
        {
            private readonly LibraryManagerDbContext _context;
            public GetLoanByIdHandler(LibraryManagerDbContext context)
            {
                _context = context;
            }
            public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
            {
                var loan = await _context.Loans
               .Include(l => l.User)
               .Include(l => l.Book)
               .SingleOrDefaultAsync(l => l.Id == request.Id);

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
