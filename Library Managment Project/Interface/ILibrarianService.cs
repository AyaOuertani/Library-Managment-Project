using Library_Managment_Project.DTOs.LibarianDTOs;
using Library_Managment_Project.Models;

namespace Library_Managment_Project.Interface
{
    public interface ILibrarianService
    {
        public Task<PaginatedList<GetAllLibrarianResponse>> GetAllAsync(int pageNumber, int pageSize);
        public Task<GetLibarianByIdResponse> GetByNumberAsync(int id);
        public Task<AddLibrarianResponse> AddAsync(AddLibrarianRequest request);
        public Task<UpdateLibrarianResponse> UpdateAsync(UpdateLibrarianRequest request);
        public Task<bool> DeleteAsync(int id);
    }
}
