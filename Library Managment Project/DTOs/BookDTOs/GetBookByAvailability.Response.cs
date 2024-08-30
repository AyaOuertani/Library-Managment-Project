﻿namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class GetBookByAvailabilityResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
        public string Author { get; set; }
        public int Qte { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public GetBookByAvailabilityResponse(int id, string title, int code, string author, int qte, string about, string category, DateTime publishDate, DateTime createDate, DateTime updateDate)
        {
            Id = id;
            Title = title;
            Code = code;
            Author = author;
            Qte = qte;
            About = about;
            Category = category;
            PublishDate = publishDate;
            CreatedDate = createDate;
            UpdatedDate = updateDate;
        }
    }
}
