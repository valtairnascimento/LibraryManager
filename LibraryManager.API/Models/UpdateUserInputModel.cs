namespace LibraryManager.API.Models
{
    public class UpdateUserInputModel
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
