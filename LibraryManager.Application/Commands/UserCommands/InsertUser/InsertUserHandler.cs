using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;
        public InsertUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.BirthDate);

            await _repository.Add(user);

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
