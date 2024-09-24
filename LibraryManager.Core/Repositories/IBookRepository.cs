using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task<Book?> GetDetailsById (int id);
        Task<int> Add(Book book);
        Task Update(Book book);
        Task<bool> Exists(int id);
    }
}
