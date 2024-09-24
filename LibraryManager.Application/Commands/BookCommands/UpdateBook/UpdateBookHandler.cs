using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _repository;
        public UpdateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetById(request.IdBook);

            if (book == null)
            {
                return ResultViewModel.Error("Livro nao existe");
            }

            book.Update(request.Title, request.Author, request.ISBN, request.PublicationYear);

          await _repository.Update(book);

            return ResultViewModel.Success();
        }
    }
}
