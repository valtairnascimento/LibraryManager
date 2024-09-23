
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(int id, string name, string email, DateTime birthdate, List<string> loans)
        {
            Id = id;
            Name = name;
            Email = email;
            Birthdate = birthdate;
            Loans = loans;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthdate { get; private set; }
        public List<string> Loans { get; private set; }

        public static UserViewModel FromEntity(User user)
        {
            var loans = user.Loans.Where(l => l.Book != null).Select(l => l.Book.Title).ToList();
            return new UserViewModel(user.Id, user.Name, user.Email, user.BirthDate, loans);
        }

    }
}
