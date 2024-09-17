
using LibraryManager.Application.Models;
using LibraryManager.Application.Service;
using LibraryManager.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LibraryManagerDbContext _context;
        private readonly IUserService _service;
        public UsersController(LibraryManagerDbContext context, IUserService service) 
        {
        _context = context;
        _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
           var result = _service.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
        //Post api/users
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
           var result = _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUserInputModel model) 
        { 
            var result = _service.Update(model);

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var result = _service.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
