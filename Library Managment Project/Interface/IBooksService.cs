using Library_Managment_Project.DTOs.BookDTOs;
using Library_Managment_Project.Models;

namespace Library_Managment_Project.Interface
{
    public interface IBooksService
    {
        public Task<PaginatedList<GetAllBooksResponce>> GetAllAsync(int pageNumber, int pageSize);
        public Task<GetBookByCodeResponce> GetByCodeAsync(int Code);
        public Task<GetBookByTitleResponce> GetByTitleAsync(string Title);
        public Task<PaginatedList<GetBookByAutherResponce>> GetByAutherAsync(string auther , int pageNumber , int pageSize);
        public Task<PaginatedList<GetBookByAvailabilityResponce>> GetByAvailabilityAsync(int pageNumber, int pageSize);
        public Task<AddBookResponce> AddAsync(AddBookRequest request);
        public Task<UpdateBookResponce> UpdateAsync(UpdateBookRequest request);
        public Task<bool> DeleteAsync(string id);
    }
}
