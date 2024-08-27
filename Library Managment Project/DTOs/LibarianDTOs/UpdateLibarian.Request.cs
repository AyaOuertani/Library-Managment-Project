namespace Library_Managment_Project.DTOs.LibarianDTOs
{
    public class UpdateLibarianRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string WorkSchedule { get; set; }
        public UpdateLibarianRequest(int libarianId, string email, int phoneNumber, string workSchedule)
        {
            Id = libarianId;
            Email = email;
            PhoneNumber = phoneNumber;
            WorkSchedule = workSchedule;
        }
    }
}
