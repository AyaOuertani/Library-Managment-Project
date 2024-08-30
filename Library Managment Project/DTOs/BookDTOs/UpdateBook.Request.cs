namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class UpdateBookRequest
    {
        public int Id {  get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Qte { get; set; }
        public string? About { get; set; }
        public string? Category { get; set; }
        public int? Code { get; set; }
    
    }
}
