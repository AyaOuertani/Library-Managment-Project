using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class AddMemberRequest
    {
        public int MemberId { get; set; }
        public long MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber {  get; set; }
        public  MemberShipType MemberShipType { get; set; }
        public AddMemberRequest(int memberId, long memberNumber, string firstName, string lastName, string email, int phoneNumber , MemberShipType memberShipType)
        {
            MemberId = memberId;
            MemberNumber = memberNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            MemberShipType = memberShipType;    
        }
    }
}
