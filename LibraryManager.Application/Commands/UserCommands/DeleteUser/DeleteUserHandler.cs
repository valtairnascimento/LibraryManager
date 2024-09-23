using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly LibraryManagerDbContext _context;
        public DeleteUserHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuario nao existe");
            }

            user.SetAsDeleted();
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
