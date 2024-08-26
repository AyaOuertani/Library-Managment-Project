using Library_Managment_Project.DTOs.BookDTOs;

namespace Library_Managment_Project.Interface
{
    public interface IBooksService
    {
        public Task<GetBookByCodeResponse> GetByCodeAsync(int Code);
        public Task<GetBookByTitleResponse> GetByTitleAsync(string Title);
        public Task<GetBookByAuthorResponse> GetByAutherAsync(string Auther);
        public Task<IEnumerable<GetBookByAvailabilityResponce>> GetByAvailabilityAsync();
        public Task<AddBookResponse> AddAsync(AddBookRequest request);
        public Task<UpdateBookResponse> UpdateAsync(UpdateBookRequest request);
        public Task<bool> DeleteAsync(string id);
    }
}
