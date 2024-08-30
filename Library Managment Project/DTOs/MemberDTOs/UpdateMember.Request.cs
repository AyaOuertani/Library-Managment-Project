using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class UpdateMemberRequest
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public int? PhoneNumber { get; set; }
        public MemberShipType? MemberShipType { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
