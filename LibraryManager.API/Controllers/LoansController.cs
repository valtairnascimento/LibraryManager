
using LibraryManager.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CreateLoanInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new {id =1}, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,UpdateLoanInputModel model) 
        {

            return Ok();
        }
    }
}
