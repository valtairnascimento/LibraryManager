using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetAll
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<List<BookViewModel>>>
    {
        private readonly IBookRepository _repository;
        public GetAllBooksHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<BookViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetAll();

            var model = book.Select(BookViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(model);
        }
    }
}
