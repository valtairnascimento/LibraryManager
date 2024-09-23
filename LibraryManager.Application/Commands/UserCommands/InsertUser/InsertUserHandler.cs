using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistance;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly LibraryManagerDbContext _context;
        public InsertUserHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.BirthDate);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
