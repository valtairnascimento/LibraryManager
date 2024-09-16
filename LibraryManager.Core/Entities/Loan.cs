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


        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public void Update(int idUser, int idBook, DateTime returnDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;
        }


    }
}
