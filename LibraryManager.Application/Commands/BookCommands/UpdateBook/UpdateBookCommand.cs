using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommand :IRequest<ResultViewModel>
    {
        public UpdateBookCommand(int idBook, string title, string author, string iSBN, DateTime publicationYear)
        {
            IdBook = idBook;
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationYear { get; set; }
    }
}
