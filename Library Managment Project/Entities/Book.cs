namespace Library_Managment_Project.Entities
{
    public class Book
    {
        public  int ID { get; set; }
        public string Title { get; set; }
        public int Code {  get; set; }
        public string Auther { get; set; }
        public int Qte { get; set; }
        public string About { get; set; }
        public string Category { get; set; }
        public DateTime  PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<LoansBook> Loans { get; set; }

    }
}
