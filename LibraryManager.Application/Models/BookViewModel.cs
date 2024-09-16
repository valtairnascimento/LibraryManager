
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string isbn, DateTime publicationYear)
        {
            Id = id;
            Title = title;
            Author = author;
            Isbn = isbn;
            PublicationYear = publicationYear;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public DateTime PublicationYear { get; private set; }

        public static BookViewModel FromEntity(Book book)
            => new(book.Id, book.Title, book.Author, book.ISBN, book.PublicationYear);
    }
}
