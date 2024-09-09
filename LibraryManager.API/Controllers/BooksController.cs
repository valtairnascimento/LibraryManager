
using LibraryManager.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string search)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CreateNewBookModel model)
        {
            return CreatedAtAction(nameof(GetById), new {id = 1}, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateBookModel model )
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            return NoContent();
        }
    
    }
}
