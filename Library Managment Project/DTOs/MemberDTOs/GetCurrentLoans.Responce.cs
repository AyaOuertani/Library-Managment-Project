using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class GetCurrentLoansResponce
    {
        public string BookTitle { get; set; }
        public int Code { get; set; }
        public string Auther { get; set; }
        public DateTime DateOfLoan { get; set; }
        public DateTime DateOfReturn { get; set; }
        public StatusOfLoans LoanStatus { get; set; }
        public GetCurrentLoansResponce(string bookTitle, int code, string auther, StatusOfLoans statusOfLoans, DateTime dateOfLoan, DateTime dateOfReturn)
        {
            BookTitle = bookTitle;
            Code = code;
            Auther = auther;
            DateOfLoan = dateOfLoan;
            DateOfReturn = dateOfReturn;
            LoanStatus = statusOfLoans;

        }
    }
}
