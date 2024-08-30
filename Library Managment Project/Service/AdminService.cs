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
            Admin? admin = await _dbcontext.Admin.FirstOrDefaultAsync(admin=>admin.FirstName==AdminRequest.FirstName)
                                              ?? throw new KeyNotFoundException("Memeber Not Found");


            admin.Email = AdminRequest.Email ??  admin.Email;
            admin.Phone = AdminRequest.PhoneNumber ?? admin.Phone; 
            admin.Password = AdminRequest.Password ?? admin.Password;
            admin.UpdateAt = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
            return "Updated Successfully";
        }
        #endregion
    }
}
