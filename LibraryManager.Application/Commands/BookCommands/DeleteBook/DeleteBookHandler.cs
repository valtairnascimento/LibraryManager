using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _repository;
        public DeleteBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetById(request.Id);

            if (book == null)
            {
                return ResultViewModel.Error("Livro nao existe");
            }

            book.SetAsDeleted();
            await _repository.Update(book);

            return ResultViewModel.Success();
        }
    }
}
