namespace LibraryManager.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook, DateTime loanDate) : base()
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = DateTime.Now;
        }

        public int Id { get; set; }
        public int IdUser { get;  set; }
        public User User { get;  set; }
        public int IdBook { get;  set; }
        public Book Book { get;  set; }
        public DateTime LoanDate { get;  set; }
        public DateTime ReturnDate { get;  set; }

        public void Update(int idUser, int idBook, DateTime returnDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;
        }


    }
}
