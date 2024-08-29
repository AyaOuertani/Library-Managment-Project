﻿using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class GetAllMembersResponse
    {
        public long MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public List<string>? Bookloaned { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public GetAllMembersResponse (long memberNumber, string firstName, string lastName, string email, int phoneNumber, MemberShipType memberShipType, List<string> BookLoaneds,DateTime createDate, DateTime updateDate)
        {
            MemberNumber = memberNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            MemberShipType = memberShipType;
            Bookloaned = bookLoaned;
            CreateAt = createDate;
            UpdateAt = updateDate;
            Bookloaned = BookLoaneds;
        }
    }
}