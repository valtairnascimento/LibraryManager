using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.InsertBook
{
    public class InsertBookCommand :IRequest<ResultViewModel<int>>
    {
        public InsertBookCommand(string title, string author, string iSBN, DateTime publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationYear { get; set; }

        public Book ToEntity()
            => new(Title, Author, ISBN, PublicationYear);
    }
}
