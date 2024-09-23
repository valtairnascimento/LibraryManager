using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.UserQueries.GetAll
{
    public class GetAllUsersQuery :IRequest<ResultViewModel<List<UserViewModel>>>
    {
    }
}
