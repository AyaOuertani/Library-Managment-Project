using Library_Managment_Project.DTOs.BookDTOs;

namespace Library_Managment_Project.Interface
{
    public interface IBooksService
    {
        public Task<GetBookByCodeResponce> GetByCodeAsync(int Code);
        public Task<GetBookByTitleResponce> GetByTitleAsync(string Title);
        public Task<GetBookByAutherResponce> GetByAutherAsync(string Auther);
        public Task<IEnumerable<GetBookByAvailabilityResponce>> GetByAvailabilityAsync();
        public Task<AddBookResponce> AddAsync(AddBookRequest request);
        public Task<UpdateBookResponce> UpdateAsync(UpdateBookRequest request);
        public Task<bool> DeleteAsync(string id);
    }
}
