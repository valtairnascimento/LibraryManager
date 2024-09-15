using LibraryManager.API.Entities;

namespace LibraryManager.API.Models
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email, DateTime birthdate)
        {
            Name = name;
            Email = email;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthdate { get; private set; }

        public static UserViewModel FromEntity(User user)
            => new(user.Name, user.Email, user.BirthDate);
    }
}
