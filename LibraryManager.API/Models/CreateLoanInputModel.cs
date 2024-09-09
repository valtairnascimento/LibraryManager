namespace LibraryManager.API.Models
{
    public class CreateLoanInputModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime Devolution {  get; set; }



    }
}
