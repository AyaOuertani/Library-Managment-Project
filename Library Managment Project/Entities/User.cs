using Library_Managment_Project.Enum;

namespace Library_Managment_Project.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int PhoneNumber;
        public int Phone
        {
            get { return PhoneNumber; }
            set { if (value.ToString().Length == 8) PhoneNumber = value; }
        }
        public UserRole Role { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
