using Library_Managment_Project.Entities;
using System.ComponentModel.DataAnnotations;

namespace Library_Managment_Project.DTOs.BookDTOs
{
    public class AddBookRequest
    {
        [Required]
<<<<<<< HEAD
        public int ID { get; set; }
=======
        public int Id { get; set; }
>>>>>>> 69c394ecc8895d4c71bd0b276f4145fc36110090
        public string Title { get; set; }
        public int Code { get; set; }
        public string Auther { get; set; }
        public int Qte { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
