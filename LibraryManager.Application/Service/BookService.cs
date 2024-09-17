using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Service
{
    public class BookService : IBookService
    {
        private readonly LibraryManagerDbContext _context;
        public BookService(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {

            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return ResultViewModel.Error("Livro nao existe");
            }

            book.SetAsDeleted();
            _context.Books.Update(book);
            _context.SaveChanges();

            return ResultViewModel.Success();   
        }

        public ResultViewModel<List<BookViewModel>> GetAll(string search = "")
        {
            var book = _context.Books
                 .Where(b => (search == "" || b.Title.Contains(search)) || b.Author.Contains(search));

            var model = book.Select(BookViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(model);
        }

        public ResultViewModel<BookViewModel> GetById(int id)
        {
            var book = _context.Books
                 .Include(b => b.Loans)
                 .SingleOrDefault(b => b.Id == id);

            var model = BookViewModel.FromEntity(book);
            
            if(book is null)
            {
                return ResultViewModel<BookViewModel>.Error("Livro nao existe");
            }

            return ResultViewModel<BookViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateBookInputModel model)
        {
            var book = model.ToEntity();

            _context.Books.Add(book);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(book.Id);
        }

        public ResultViewModel Update(UpdateBookInputModel model)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == model.IdBook);

            if (book == null)
            {
                return ResultViewModel.Error("Livro nao existe");
            }

            book.Update(model.Title, model.Author, model.ISBN, model.PublicationYear);

            _context.Books.Update(book);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
