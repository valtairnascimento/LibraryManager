using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.UserQueries.GetById
{
    public class GetUserByIdQuery :IRequest<ResultViewModel<UserViewModel>>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
