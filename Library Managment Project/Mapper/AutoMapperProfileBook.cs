using AutoMapper;
using Library_Managment_Project.DTOs.BookDTOs;
using Library_Managment_Project.Entities;

namespace Library_Managment_Project.Mapper
{
    public class AutoMapperProfileBook : Profile
    {
        public AutoMapperProfileBook()
        {
            CreateMap<Book, GetBookByCodeResponse>();

        }
    }
}
