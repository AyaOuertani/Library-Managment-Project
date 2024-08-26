using Library_Managment_Project.Enum;

namespace Library_Managment_Project.Entities
{
    public class Member : User
    {
        public long MemberCode { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public ICollection<LoansBook> Loans { get; set; }
    }
}
