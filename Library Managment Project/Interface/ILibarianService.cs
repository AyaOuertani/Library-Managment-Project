using Library_Managment_Project.DTOs.LibarianDTOs;
using Library_Managment_Project.Models;

namespace Library_Managment_Project.Interface
{
    public interface ILibarianService
    {
        public Task<PaginatedList<GetAllLibarianResponse>> GetAllAsync(int pageNumber, int pageSize);
        public Task<GetLibarianByIdResponse> GetByNumberAsync(int id);
        public Task<AddLibarianResponse> AddAsync(AddLibarianRequest request);
        public Task<UpdateLibarianResponse> UpdateAsync(UpdateLibarianRequest request);
        public Task<bool> DeleteAsync(int id);
    }
}
