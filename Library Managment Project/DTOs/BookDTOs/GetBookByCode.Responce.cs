namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class GetBookByCodeResponce
    {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Auther { get; set; }
            public int Qte { get; set; }
            public string About { get; set; }
            public string Category { get; set; }
            public DateTime PublishDate { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }
            public GetBookByCodeResponce(string id ,string title, string auther, int qte, string about, string category, DateTime publishDate, DateTime createDate, DateTime updateDate)
            {
                Id = id;
                Title = title;
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

