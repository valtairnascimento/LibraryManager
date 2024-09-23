using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Queries.UserQueries.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
    {
        private readonly LibraryManagerDbContext _context;
        public GetAllUsersHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
               .Include(u => u.Loans)
                   .ThenInclude(l => l.Book)
               .ToListAsync();

            var model = users.Select(UserViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserViewModel>>.Success(model);
        }
    }
}
