using LibraryManager.API.Entities;

namespace LibraryManager.API.Models
{
    public class CreateBookInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationYear { get; set; }

        public Book ToEntity() 
            => new(Title, Author, ISBN, PublicationYear);

    }
}
