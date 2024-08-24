﻿using Library_Managment_Project.Entities;

namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class AddBookResponce
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
        public string Auther { get; set; }
        public int Qte { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public AddBookResponce(string id, string title,int code,string auther , int qte,string about,string category, DateTime publishDate,DateTime createDate, DateTime updateDate)
        {
            ID = id;
            Title = title;
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