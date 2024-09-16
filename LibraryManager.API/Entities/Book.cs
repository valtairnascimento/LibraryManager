
namespace LibraryManager.API.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, DateTime publicationYear) : base()
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public DateTime PublicationYear { get; private set; }
        public List<Loan> Loans { get; private set; }

        public void Update(string title, string author, string isbn, DateTime publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;


        }

    }
}
