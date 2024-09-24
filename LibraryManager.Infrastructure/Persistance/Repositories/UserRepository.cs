using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryManagerDbContext _context;
        public UserRepository(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> Exists(int id)
        {
           return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users
              .Include(u => u.Loans)
                  .ThenInclude(l => l.Book)
              .ToListAsync();

            return users;
        }

        public async Task<User?> GetById(int id)
        {
           return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetDetailsById(int id)
        {
            var user = await _context.Users
                  .Include(u => u.Loans)
                      .ThenInclude(u => u.Book)
                  .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
