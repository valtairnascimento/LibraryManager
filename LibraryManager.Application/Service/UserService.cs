using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Service
{
    public class UserService : IUserService
    {
        private readonly LibraryManagerDbContext _context;
        public UserService(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuario nao existe");
            }

            user.SetAsDeleted();
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();   
        }

        public ResultViewModel<List<UserViewModel>> GetAll(string search = "")
        {

            var users = _context.Users
                .Include(u => u.Loans)
                    .ThenInclude(l => l.Book)
                .ToList();

            var model = users.Select(u => UserViewModel.FromEntity(u)).ToList();

            return ResultViewModel<List<UserViewModel>>.Success(model);
        }

        public ResultViewModel<UserViewModel> GetById(int id)
        {
            var user = _context.Users
                 .Include(u => u.Loans)
                     .ThenInclude(u => u.Book)
                 .FirstOrDefault(u => u.Id == id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuario nao existe");
            }

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateUserInputModel model)
        {
            var user = new User(model.Name, model.Email, model.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(user.Id);

        }

        public ResultViewModel Update(UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == model.IdUser);
            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuario nao existe");
            }

            user.Update(model.Name, model.Email, model.BirthDate);

            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
