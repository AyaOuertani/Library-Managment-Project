﻿namespace Library_Managment_Project.DTOs.LibarianDTOs
{
    public class UpdateLibrarianRequest
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public int? PhoneNumber { get; set; }
        public string? WorkSchedule { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
    }
}
