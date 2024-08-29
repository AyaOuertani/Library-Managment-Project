using Library_Managment_Project.DTOs.AdminDTOs;

namespace Library_Managment_Project.Interface
{
    public interface IAdminService
    {
        public Task<string> UpdateAsync(UpdateAdminRequest request);
    }
}
