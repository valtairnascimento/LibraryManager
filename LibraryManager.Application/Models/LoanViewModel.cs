
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(int idUser, int idBook, DateTime returnDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;

            LoanDate = DateTime.Now;
        }

        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public static LoanViewModel FromEntity(Loan loan)
            => new(loan.IdBook, loan.IdUser, loan.ReturnDate);
    }
}
