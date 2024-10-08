﻿using Library_Managment_Project.Enum;

namespace Library_Managment_Project.DTOs.MemberDTOs
{
    public class UpdateMemberResponse
    { 
        public int MemberNumber {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public MemberShipType MemberShipType { get; set; } 
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public UpdateMemberResponse(int memberNumber,string firstName, string lastName, string email,string password ,int phoneNumber, MemberShipType memberShipType,  DateTime createDate, DateTime updateDate)
        {
            MemberNumber = memberNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            MemberShipType = memberShipType;
            CreateAt = createDate;
            UpdateAt = updateDate;
        }
    }
}
