using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class AddMemberRequest
    {

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber {  get; set; }
        public  MemberShipType MemberShipType { get; set; }
        public string Password { get; set; }
        public AddMemberRequest( string firstName, string lastName, string email, int phoneNumber , MemberShipType memberShipType , string password )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            MemberShipType = memberShipType;   
            Password = password;
        }
    }
}
