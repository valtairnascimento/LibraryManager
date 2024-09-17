
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, int idUser, int idBook, DateTime returnDate)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;
          

            LoanDate = DateTime.Now;
        }
        public int Id {  get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public static LoanViewModel FromEntity(Loan loan)
            => new(loan.Id, loan.IdBook, loan.IdUser, loan.ReturnDate);
    }
}
