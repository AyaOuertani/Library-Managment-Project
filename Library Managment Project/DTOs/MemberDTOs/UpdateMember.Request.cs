using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class UpdateMemberRequest
    {
        public long MemberNumber { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public DateTime UpdateAt { get; set; }
        public UpdateMemberRequest(long memberNumber, string email, int phoneNumber, MemberShipType memberShipType, DateTime updateDate)
        {

            MemberNumber = memberNumber;
            Email = email;
            PhoneNumber = phoneNumber;
            MemberShipType = memberShipType;
            UpdateAt = updateDate;
        }
    }
}
