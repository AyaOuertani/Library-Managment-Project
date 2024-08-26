using Library_Managment_Project.Enum;

namespace Library_Managment_Project.Entities
{
    public class LoansBook
    {
        public int Id { get; set; }
        public DateTime  DateOfLoan { get; set; }
        public DateTime DateOfReturn { get; set; }
        public StatusOfLoans LoanStatus { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int MemberId { get; set; }
        public Member? Member { get; set; }
    }
}
