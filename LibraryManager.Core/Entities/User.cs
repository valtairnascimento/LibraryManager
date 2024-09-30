namespace LibraryManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, DateTime birthDate, string password, string role) : base()
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Role = role;

            Loans = [];

        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<Loan> Loans { get; private set; }

        public void Update(string name, string email, DateTime birthdate)
        {
            Name = name;
            Email = email;
            BirthDate = birthdate;
        }
    }
}
