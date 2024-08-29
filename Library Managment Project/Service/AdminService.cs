using Library_Managment_Project.DTOs.AdminDTOs;
using Library_Managment_Project.DTOs.MemberDTOs;
using Library_Managment_Project.Entities;
using Library_Managment_Project.Interface;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_Project.Service
{
    public class AdminService : IAdminService
    {
        #region Variables+Constracor
        private readonly ApplicationDBcontext _dbcontext;
        public AdminService(ApplicationDBcontext dbcontext) => _dbcontext = dbcontext;
        #endregion

        #region Update
        public async Task<string> UpdateAsync(UpdateAdminRequest AdminRequest)
        {
            Admin? admin = _dbcontext.Admin.Find(AdminRequest.FirstName)
                                              ?? throw new KeyNotFoundException("Memeber Not Found");


            admin.Email = AdminRequest.Email is null || AdminRequest.Email == "string" ? admin.Email : AdminRequest.Email;
            admin.Phone = AdminRequest.PhoneNumber is 0 ? admin.Phone : AdminRequest.PhoneNumber;
            admin.Password = AdminRequest.Password is null || AdminRequest.Password == "string" ? admin.Password : AdminRequest.Password;
            admin.UpdateAt = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
            return "Updated Successfully";
        }
        #endregion
    }
}
