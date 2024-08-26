namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class GetBookByCodeResponse
    {
<<<<<<< HEAD:Library Managment Project/DTOs/BookDTOs/GetBookByCode.Response.cs
            public int Id { get; set; }
=======
            public int  Id { get; set; }
>>>>>>> 69c394ecc8895d4c71bd0b276f4145fc36110090:Library Managment Project/DTOs/BookDTOs/GetBookByCode.Responce.cs
            public string Title { get; set; }
            public string Author { get; set; }
            public int Qte { get; set; }
            public string About { get; set; }
            public string Category { get; set; }
            public DateTime PublishDate { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }
<<<<<<< HEAD:Library Managment Project/DTOs/BookDTOs/GetBookByCode.Response.cs
            public GetBookByCodeResponse(int id ,string title, string auther, int qte, string about, string category, DateTime publishDate, DateTime createDate, DateTime updateDate)
=======
            public GetBookByCodeResponse(int id ,string title, string author, int qte, string about, string category, DateTime publishDate, DateTime createDate, DateTime updateDate)
>>>>>>> 69c394ecc8895d4c71bd0b276f4145fc36110090:Library Managment Project/DTOs/BookDTOs/GetBookByCode.Responce.cs
            {
                Id = id;
                Title = title;
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

