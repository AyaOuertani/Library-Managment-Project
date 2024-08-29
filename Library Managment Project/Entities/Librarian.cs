using static System.Net.WebRequestMethods;

namespace Library_Managment_Project.Entities
{
    public class Librarian : User
    {
        public string WorkSchedule { get; set; } = "https://calendar.google.com/";
    }
}
