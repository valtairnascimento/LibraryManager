﻿using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommand :IRequest<ResultViewModel>
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
