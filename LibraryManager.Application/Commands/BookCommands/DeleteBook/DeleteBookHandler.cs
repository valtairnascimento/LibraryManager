using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
    {
        private readonly LibraryManagerDbContext _context;
        public DeleteBookHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.Id);

            if (book == null)
            {
                return ResultViewModel.Error("Livro nao existe");
            }

            book.SetAsDeleted();
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
