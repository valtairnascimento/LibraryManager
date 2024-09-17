using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Service
{
    public class LoanService : ILoanService
    {
        private readonly LibraryManagerDbContext _context;
        public LoanService(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);
            if (loan == null)
            {
                return ResultViewModel<LoanViewModel>.Error("Emprestimo nao existe");
            }
            loan.SetAsDeleted();
            _context.Loans.Update(loan);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<LoanViewModel>> GetAll(string search = "")
        {
            var loan = _context.Loans.
                   Include(l => l.User)
                   .Include(l => l.Book)
                   .Where(l => !l.IsDeleted)
                   .ToList();

            var model = loan.Select(LoanViewModel.FromEntity).ToList();

            return ResultViewModel<List<LoanViewModel>>.Success(model); 
        }

        public ResultViewModel<LoanViewModel> GetById(int id)
        {

            var loan = _context.Loans
                .Include(l => l.User)
                .Include(l => l.Book)
                .SingleOrDefault(l => l.Id == id);

            if (loan is null)
            {
                return ResultViewModel<LoanViewModel>.Error("Emprestimo nao existe");
            }

            var model = LoanViewModel.FromEntity(loan);

            return ResultViewModel<LoanViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateLoanInputModel model)
        {
            var loan = model.ToEntity();

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(loan.Id);

        }

        

        public ResultViewModel<string> ReturnBook(int id, DateTime returnDate)
        {
            var loan = _context.Loans.Find(id);

            if (loan is null) 
            {
                return ResultViewModel<string>.Error("Empréstimo não encontrado.");
            }

            if (returnDate < loan.LoanDate) 
            {
                return ResultViewModel<string>.Error("A data de devolucao nao pode ser menor que a data de emprestimo");
            }

            loan.ReturnDate = returnDate;
            _context.SaveChanges();

            var loanDays = 3;
            var addDate = loan.LoanDate.AddDays(loanDays);
            var delayDays = (returnDate - addDate).Days;

            if (delayDays > 0) 
            {
                return ResultViewModel<string>.Success($"Atraso de {delayDays} dias na devolucao do emprestimo");
            }

            return ResultViewModel<string>.Success("Livro devolvido no prazo correto");

        }
    }
}
