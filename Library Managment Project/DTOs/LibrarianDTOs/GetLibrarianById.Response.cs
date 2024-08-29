namespace Library_Managment_Project.DTOs.LibarianDTOs
{
    public class GetLibarianByIdResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string WorkSchedule { get; set; }
        public GetLibarianByIdResponse(string firstName, string lastName, string email, int phoneNumber, string workSchedule)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            WorkSchedule = workSchedule;
        }
    }
}
