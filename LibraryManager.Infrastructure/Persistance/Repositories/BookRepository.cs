using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistance.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly LibraryManagerDbContext _context;
        public BookRepository(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Books.AnyAsync(book => book.Id == id);
        }

        public async Task<List<Book>> GetAll()
        {
            var book = await _context.Books           
            .ToListAsync();

            return book;
        }
        public async Task<Book?> GetById(int id)
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book?> GetDetailsById(int id)
        {
            var book = await _context.Books
               .Include(b => b.Loans)
               .SingleOrDefaultAsync(b => b.Id == id);

            return book;
        }

        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
