
using LibraryManager.API.Models;
using LibraryManager.API.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
      private readonly LibraryManagerDbContext _context;
        public LoansController(LibraryManagerDbContext context) 
        {
           _context = context;  
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var loan = _context.Loans.
                Include(l => l.User)
                .Include(l => l.Book)
                .Where(l => !l.IsDeleted)
                .ToList();

            var model = loan.Select(LoanViewModel.FromEntity).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            var loan = _context.Loans
                .Include(l => l.User)
                .Include(l => l.Book)
                .SingleOrDefault(l => l.Id == id);

            var model = LoanViewModel.FromEntity(loan);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateLoanInputModel model)
        {
            var loan = model.ToEntity();

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id =1}, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,UpdateLoanInputModel model) 
        {

            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);
            if (loan == null)
            {
                return NotFound();
            }

            loan.Update(model.IdBook, model.IdLoan, model.ReturnDate);

            _context.Loans.Update(loan);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            loan.SetAsDeleted();
            _context.Loans.Update(loan);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
