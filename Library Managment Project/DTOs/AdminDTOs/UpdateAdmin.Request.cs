namespace Library_Managment_Project.DTOs.AdminDTOs
{
    public class UpdateAdminRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int PhoneNumber;
    }
}
