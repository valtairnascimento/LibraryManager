

using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistance.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryManagerDbContext _context;
        public LoanRepository(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();

            return loan.Id;
        }

       
        public async Task<bool> Exists(int id)
        {
            return await _context.Loans.AnyAsync(loan => loan.Id == id);
        }

        public async Task<List<Loan>> GetAll()
        {
            var loan = await _context.Loans
                    .Include(l => l.User)
                    .Include(l => l.Book)
                    .Where(l => !l.IsDeleted)
                    .ToListAsync();

            return loan;
        }

        public async Task<Loan?> GetById(int id)
        {
           return await _context.Loans.SingleOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Loan?> GetDetailsById(int id)
        {
            var loan = await _context.Loans
              .Include(l => l.User)
              .Include(l => l.Book)
              .SingleOrDefaultAsync(l => l.Id == id);

            return loan;
        }

        
        public async Task Update(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}
