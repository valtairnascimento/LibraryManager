using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.InsertLoan
{
    public class InsertLoanCommand : IRequest<ResultViewModel<int>>
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }

        public Loan ToEntity()
            => new(IdUser, IdBook, LoanDate);
    }
}
