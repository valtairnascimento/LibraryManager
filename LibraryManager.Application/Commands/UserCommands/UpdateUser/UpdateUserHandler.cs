using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public UpdateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.IdUser);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuario nao existe");
            }

            user.Update(request.Name, request.Email, request.BirthDate);

            await _repository.Update(user);

            return ResultViewModel.Success();
        }
    }
}
