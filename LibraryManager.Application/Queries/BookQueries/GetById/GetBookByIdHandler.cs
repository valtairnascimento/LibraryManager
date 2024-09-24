using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, ResultViewModel<BookViewModel>>
    {
        private readonly IBookRepository _repository;
        public GetBookByIdHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetDetailsById(request.Id);            

            if (book is null)
            {
                return ResultViewModel<BookViewModel>.Error("Livro nao existe");
            }

            var model = BookViewModel.FromEntity(book);

            return ResultViewModel<BookViewModel>.Success(model);
        }
    }
}
