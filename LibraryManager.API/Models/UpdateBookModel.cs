namespace LibraryManager.API.Models
{
    public class UpdateBookModel
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public int Quantity { get; set; }
    }
}
