using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.InsertBook
{
    public class InsertBookHandler : IRequestHandler<InsertBookCommand, ResultViewModel<int>>
    {
        private readonly LibraryManagerDbContext _context;
        public InsertBookHandler(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(book.Id);
        }
    }
}
