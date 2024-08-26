using Library_Managment_Project.DTOs.MemberDTOs;
using Library_Managment_Project.Models;
namespace Library_Managment_Project.Interface
{
    public interface IMemberService
    {
        public Task<PaginatedList<GetAllMembersResponse>> GetAllAsync(int pageNumber, int pageSize);
        public Task<GetMemberByNumberResponse> GetByNumberAsync(long number);
        public Task<PaginatedList<GetLoanedBooksResponse>> GetLoanedAsync(int memberId, int pageNumber, int pageSize);
        public Task<PaginatedList<GetCurrentLoansResponse>> GetCurrentLoansAsync(int memberId, int pageNumber, int pageSize);
        public Task<AddMemberResponse> AddAsync(AddMemberRequest request);
        public Task<UpdateMemberResponse> UpdateAsync(UpdateMemberRequest request);
        public Task<bool> DeleteAsync(long memberNumber);
    }
}
