
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class CreateLoanInputModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }

        public Loan ToEntity()
            => new(IdUser, IdBook, LoanDate);

    }
}
