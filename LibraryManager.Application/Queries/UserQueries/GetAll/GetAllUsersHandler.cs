using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.UserQueries.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
    {
        private readonly IUserRepository _repository;
        public GetAllUsersHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAll();

            var model = users.Select(UserViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserViewModel>>.Success(model);
        }
    }
}
