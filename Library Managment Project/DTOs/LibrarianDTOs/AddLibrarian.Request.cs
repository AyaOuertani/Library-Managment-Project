using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.LibarianDTOs
{
    public class AddLibrarianRequest
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string WorkSchedule { get; set; }
        public string Password { get; set; }
        public AddLibrarianRequest( string firstName, string lastName, string email, int phoneNumber, string workSchedule, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            WorkSchedule = workSchedule;
            Password = password;
        }
    }
}
