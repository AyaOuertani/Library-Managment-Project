using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class GetCurrentLoansResponse
    {
        public string BookTitle { get; set; }
        public int Code { get; set; }
        public string Author { get; set; }
        public DateTime DateOfLoan { get; set; }
        public DateTime DateOfReturn { get; set; }
        public StatusOfLoans LoanStatus { get; set; }
        public GetCurrentLoansResponse(string bookTitle, int code, string author, StatusOfLoans statusOfLoans, DateTime dateOfLoan, DateTime dateOfReturn)
        {
            BookTitle = bookTitle;
            Code = code;
            Author = author;
            DateOfLoan = dateOfLoan;
            DateOfReturn = dateOfReturn;
            LoanStatus = statusOfLoans;

        }
    }
}
