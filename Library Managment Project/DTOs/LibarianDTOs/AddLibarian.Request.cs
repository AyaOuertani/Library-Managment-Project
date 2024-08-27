using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.LibarianDTOs
{
    public class AddLibarianRequest
    {
        public int LibarianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string WorkSchedule { get; set; }
        public AddLibarianRequest(int libarianId,  string firstName, string lastName, string email, int phoneNumber, string workSchedule)
        {
            LibarianId = libarianId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            WorkSchedule = workSchedule;
        }
    }
}
