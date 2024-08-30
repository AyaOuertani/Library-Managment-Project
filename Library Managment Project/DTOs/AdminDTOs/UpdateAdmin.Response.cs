namespace Library_Managment_Project.DTOs.AdminDTOs
{
    public class UpdateAdminResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime UpdatedAt { get; set;}

        public UpdateAdminResponse(int id, string firstName, string lastName, string email, int phoneNumber, DateTime updatedAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            UpdatedAt = updatedAt;
        }
    }
}
