using Library_Managment_Project.DTOs.MemberDTOs;
using Library_Managment_Project.Models;
namespace Library_Managment_Project.Interface
{
    public interface IMemberService
    {
        public Task<PaginatedList<GetAllMembersResponce>> GetAllAsync(int pageNumber, int pageSize);
        public Task<GetMemberByNumberResponce> GetByNumberAsync(long number);
        public Task<PaginatedList<GetLoanedBooksResponce>> GetLoanedAsync(string memberId, int pageNumber, int pageSize);
        public Task<PaginatedList<GetCurrentLoansResponce>> GetCurrentLoansAsync(string memberId, int pageNumber, int pageSize);
        public Task<AddMemberResponce> AddAsync(AddMemberRequest request);
        public Task<UpdateMemberResponce> UpdateAsync(UpdateMemberRequest request);
        public Task<bool> DeleteAsync(long memberNumber);
    }
}
