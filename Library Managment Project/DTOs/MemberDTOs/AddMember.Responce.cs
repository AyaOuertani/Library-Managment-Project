namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class AddMemberResponce
    {
        public long MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; }

        public int PhoneNumber;
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public AddMemberResponce(long memberNumber, string firstName, string lastName, string email, string password, int phoneNumber, DateTime createAt, DateTime updateAt)
        {
            MemberNumber = memberNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            CreateAt = createAt;
            UpdateAt = updateAt;
        }
    }
}
