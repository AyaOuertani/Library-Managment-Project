using AutoMapper;
using Library_Managment_Project.DTOs.LoanBookDTOs;
using Library_Managment_Project.Entities;

namespace Library_Managment_Project.Mapper
{
    public class AutoMapperProfileLoanBook : Profile
    {
        public AutoMapperProfileLoanBook()
        {
            CreateMap<LoansBook, LoanBookResponse>();
            CreateMap<LoanBookRequest, LoansBook>();
        }
    }
}
