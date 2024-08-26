using Library_Managment_Project.DTOs.BookDTOs;
using Library_Managment_Project.Models;

namespace Library_Managment_Project.Interface
{
    public interface IBooksService
    {
        public Task<PaginatedList<GetAllBooksResponse>> GetAllAsync(int pageNumber, int pageSize);
        public Task<GetBookByCodeResponse> GetByCodeAsync(int Code);
        public Task<GetBookByTitleResponse> GetByTitleAsync(string Title);
        public Task<PaginatedList<GetBookByAuthorResponse>> GetByAutherAsync(string auther , int pageNumber , int pageSize);
        public Task<PaginatedList<GetBookByAvailabilityResponse>> GetByAvailabilityAsync(int pageNumber, int pageSize);
        public Task<AddBookResponse> AddAsync(AddBookRequest request);
        public Task<UpdateBookResponse> UpdateAsync(UpdateBookRequest request);
        public Task<bool> DeleteAsync(int id);
    }
}
