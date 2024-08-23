namespace Library_Managment_Project.Entities
{
    public class LoansBooks
    {
        public DateTime  DateOfLoan { get; set; }
        public DateTime DateOfReturn { get; set; }
        public StatusOfLoans LoanStatus { get; set; }
        public int BookId { get; set; }
        public Book? Books { get; set; }
        public int MemberId { get; set; }
        public Members? Members { get; set; }
    }
    public enum StatusOfLoans
    {
        Pending,
        Returned,
        Overdue
    }
}
