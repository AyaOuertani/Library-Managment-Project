namespace Library_Managment_Project.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; }

        public int PhoneNumber;
        public int phone
        {
            get { return PhoneNumber; }
            set { if (value.ToString().Length == 8) PhoneNumber = value; }
        }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
