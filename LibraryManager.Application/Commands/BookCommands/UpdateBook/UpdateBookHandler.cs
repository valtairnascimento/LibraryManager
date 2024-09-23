using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
    {
        private readonly LibraryManagerDbContext _context;
        public UpdateBookHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.IdBook);

            if (book == null)
            {
                return ResultViewModel.Error("Livro nao existe");
            }

            book.Update(request.Title, request.Author, request.ISBN, request.PublicationYear);

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
