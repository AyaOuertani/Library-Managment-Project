using Library_Managment_Project.DTOs.BookDTOs;
using Library_Managment_Project.DTOs.MemberDTOs;
using Library_Managment_Project.Entities;

namespace Library_Managment_Project.DTOs.LoanBookDTOs
{
    public class LoanBookResponse
    {
        public int LoanId { get; set; }
        public DateTime DateOfReturn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BookTitle { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public LoanBookResponse(LoansBook loanBook)
        {
            LoanId = loanBook.Id;
            DateOfReturn = loanBook.DateOfReturn;
            FirstName = loanBook.Member.FirstName;
            LastName = loanBook.Member.LastName;
            BookTitle = loanBook.Book.Title;
            PhoneNumber = loanBook.Member.PhoneNumber;
            Email = loanBook.Member.Email;
        }

    }
}
