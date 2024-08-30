namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class AddMemberResponse
    {
        public int Id { get; set; }
        public int MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int PhoneNumber { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public AddMemberResponse(int id , int memberNumber, string firstName, string lastName, string email, string password, int phoneNumber, DateTime createAt, DateTime updateAt)
        {
            Id = id;
            MemberNumber = memberNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            CreateAt = createAt;
            UpdateAt = updateAt;
        }
    }
}
