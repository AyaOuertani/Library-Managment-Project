using Library_Managment_Project.Entities;
using System.ComponentModel.DataAnnotations;

namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class AddBookRequest
    {
        [Required]
        public string ID { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
        public string Auther { get; set; }
        public int Qte { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
