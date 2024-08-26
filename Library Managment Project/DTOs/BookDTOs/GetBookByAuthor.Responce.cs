namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class GetBookByAuthorResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
        public int Qte { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public GetBookByAuthorResponse(int id, string title, int code, int qte, string about, string category, DateTime publishDate, DateTime createDate, DateTime updateDate)
        {
            Id = id;
            Title = title;
            Code = code;
            Qte = qte;
            About = about;
            Category = category;
            PublishDate = publishDate;
            CreatedDate = createDate;
            UpdatedDate = updateDate;
        }
    }
}
