
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class CreateUserInputModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public User ToEntity()
           => new(Name, Email, BirthDate);
    }
}
