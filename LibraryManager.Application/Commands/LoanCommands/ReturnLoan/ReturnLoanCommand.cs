using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.ReturnLoan
{
    public class ReturnLoanCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
