using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.InsertUser
{
    public class InsertUserCommand : IRequest<ResultViewModel<int>>
    {
        public InsertUserCommand(string name, string email, string password, string role, DateTime birthDate)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            BirthDate = birthDate;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
