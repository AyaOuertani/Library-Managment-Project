namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class UpdateBookRequest
    {
        public string Id {  get; set; } 
        public int Qte { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
    }
}
