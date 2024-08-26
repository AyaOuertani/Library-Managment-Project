using Library_Managment_Project.Entities;
using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class GetMemberByNumberResponce
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public List<string>? Bookloaned { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public GetMemberByNumberResponce(string firstName, string lastName, string email, int phoneNumber, MemberShipType memberShipType, List<GetLoanedBooksResponce> BookLoaned, DateTime createDate, DateTime updateDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            MemberShipType = memberShipType;
            CreateAt = createDate;
            UpdateAt = updateDate;
        }
    }
}
