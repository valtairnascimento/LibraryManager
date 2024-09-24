using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAll();
        Task<Loan?> GetDetailsById(int id);
        Task<Loan?> GetById(int id);
        Task<int> Add(Loan loan);
        Task Update(Loan loan);    
        //Task Delete(Loan loan);
        Task<bool> Exists(int id);
    }
}
