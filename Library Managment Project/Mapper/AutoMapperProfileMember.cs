using AutoMapper;
using Library_Managment_Project.DTOs.MemberDTOs;
using Library_Managment_Project.Entities;

namespace Library_Managment_Project.Mapper
{
    public class AutoMapperProfileMember : Profile
    {
        public AutoMapperProfileMember()
        {
            CreateMap<Member, GetMemberResponse>();
        }
    }
}
