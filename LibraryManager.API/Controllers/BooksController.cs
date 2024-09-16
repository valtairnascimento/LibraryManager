
using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryManagerDbContext _context;
        public BooksController(LibraryManagerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var book = _context.Books
                .Where(b => (search == "" || b.Title.Contains(search)) || b.Author.Contains(search));

            var model = book.Select(BookViewModel.FromEntity).ToList();            

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books
                .Include(b => b.Loans)
                .SingleOrDefault(b => b.Id == id);

            var model = BookViewModel.FromEntity(book);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateBookInputModel model)
        {

            var book = model.ToEntity();
            
            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id = 1}, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateBookInputModel model)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null) 
            { 
            return NotFound();
            }

            book.Update(model.Title, model.Author, model.ISBN, model.PublicationYear);

            _context.Books.Update(book);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {

            var book = _context.Books.SingleOrDefault(b =>b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.SetAsDeleted();
            _context.Books.Update(book);
            _context.SaveChanges();

            return NoContent();
        }

     
    }
}
