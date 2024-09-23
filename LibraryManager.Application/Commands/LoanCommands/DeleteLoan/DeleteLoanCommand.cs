using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<ResultViewModel>
    {
        public DeleteLoanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
