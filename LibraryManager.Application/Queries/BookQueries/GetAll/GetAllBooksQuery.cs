using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetAll
{
    public class GetAllBooksQuery :IRequest<ResultViewModel<List<BookViewModel>>>
    {
        public string Search { get; set; } = "";
    }
}
