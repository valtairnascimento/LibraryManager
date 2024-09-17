
using LibraryManager.Application.Models;
using LibraryManager.Application.Service;
using LibraryManager.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
      private readonly LibraryManagerDbContext _context;
        private readonly ILoanService _service;
        public LoansController(LibraryManagerDbContext context, ILoanService service) 
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

        [HttpPost]
        public IActionResult Post(CreateLoanInputModel model)
        {
            var result = _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, model);
        }

        [HttpPut("return/{id}")]
        public IActionResult Put(int id, DateTime returnDate) 
        {

          var result = _service.ReturnBook(id, returnDate);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
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
