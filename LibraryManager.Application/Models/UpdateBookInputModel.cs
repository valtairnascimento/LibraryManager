namespace LibraryManager.Application.Models
{
    public class UpdateBookInputModel
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationYear { get; set; }
    }
}
