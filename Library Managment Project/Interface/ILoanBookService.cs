using Library_Managment_Project.DTOs.LoanBookDTOs;

namespace Library_Managment_Project.Interface
{
    public interface ILoanBookService
    {
        Task<LoanBookResponse> LoanBook(LoanBookRequest loanBookRequest);
        Task<string> ReturnBook(ReturnLoanedBookRequest returnLoanedBookRequest);
    }
}
