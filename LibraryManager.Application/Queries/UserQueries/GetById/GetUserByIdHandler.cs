using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.UserQueries.GetById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private readonly IUserRepository _repository;
        public GetUserByIdHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetDetailsById(request.Id);    

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuario nao existe");
            }

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }
    }
}
