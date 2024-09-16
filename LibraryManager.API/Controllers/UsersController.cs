
using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LibraryManagerDbContext _context;  
        public UsersController(LibraryManagerDbContext context) 
        {
        _context = context;
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {

            var users = _context.Users
                .Include(u => u.Loans)
                    .ThenInclude(l => l.Book)
                .ToList();

            var model = users.Select(u => UserViewModel.FromEntity(u)).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var user = _context.Users
                .Include(u => u.Loans)
                    .ThenInclude(u => u.Book)
                .FirstOrDefault(u => u.Id == id);  

            if (user is null)
            {
                return NotFound();  
            }

            var model = UserViewModel.FromEntity(user);

            return Ok(model);
        }
        //Post api/users
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var user = new User(model.Name, model.Email, model.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUserInputModel model) 
        { 
            var user = _context.Users.SingleOrDefault(u => u.Id == id); 
            if (user is null)
            {
                return NotFound();
            }

            user.Update(model.Name, model.Email, model.BirthDate);

            _context.Users.Update(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user is null)
            {
                return NotFound();
            }

            user.SetAsDeleted();
            _context.Users.Update(user);
            _context.SaveChanges(); 


            return NoContent();
        }
    }
}
