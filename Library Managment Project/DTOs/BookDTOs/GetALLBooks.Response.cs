using Library_Managment_Project.Entities;

namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class GetAllBooksResponse
    {
        public string Title { get; set; }
        public int Code { get; set; }
        public string Author { get; set; }
        public int Qte { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public GetAllBooksResponse(string title, int code, string author, int qte, string about, string category, DateTime publishDate)
        {
            Title = title;
            Code = code;
            Author = author;
            Qte = qte;
            About = about;
            Category = category;
            PublishDate = publishDate;
        }
    }
}
