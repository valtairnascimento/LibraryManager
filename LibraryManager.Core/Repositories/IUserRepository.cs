using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User?> GetDetailsById(int id);
        Task<int> Add(User user);
        Task Update (User user);
        Task<bool> Exists (int id);
    }
}
