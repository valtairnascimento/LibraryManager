
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, int idUser, int idBook, DateTime returnDate, string userName, string bookName)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;
            UserName = userName;
            BookName = bookName;         

            LoanDate = DateTime.Now;
        }
        public int Id {  get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public int IdBook { get; set; }
        public string BookName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public static LoanViewModel FromEntity(Loan loan)
            => new(loan.Id, loan.IdUser, loan.IdBook, loan.ReturnDate, loan.User.Name, loan.Book.Title);
    }
}
