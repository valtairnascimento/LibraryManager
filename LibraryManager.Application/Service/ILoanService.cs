using LibraryManager.Application.Models;

namespace LibraryManager.Application.Service
{
    public interface ILoanService
    {
        ResultViewModel<List<LoanViewModel>> GetAll(string search = "");
        ResultViewModel<LoanViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateLoanInputModel model);
        ResultViewModel<string> ReturnBook(int id, DateTime returnDate);
        ResultViewModel Delete(int id);
    }
}
