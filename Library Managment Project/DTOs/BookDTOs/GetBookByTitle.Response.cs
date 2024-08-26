namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class GetBookByTitleResponse
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Auther { get; set; }
        public int Qte { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public GetBookByTitleResponse(int id, int code, string auther, int qte, string about, string category, DateTime publishDate, DateTime createDate, DateTime updateDate)
        {
            Id = id;
            Code = code;
            Auther = auther;
            Qte = qte;
            About = about;
            Category = category;
            PublishDate = publishDate;
            CreatedDate = createDate;
            UpdatedDate = updateDate;
        }
    }
}
