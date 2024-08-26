using Library_Managment_Project.Enum;

namespace Library_Managment_Project.Entities
{
    public class LoansBook
    {
        public string Id { get; set; }
        public DateTime  DateOfLoan { get; set; }
        public DateTime DateOfReturn { get; set; }
        public StatusOfLoans LoanStatus { get; set; }
        public string BookId { get; set; }
        public Book? Book { get; set; }
        public string MemberId { get; set; }
        public Member? Member { get; set; }
    }
}
