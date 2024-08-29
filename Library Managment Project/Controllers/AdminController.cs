using Library_Managment_Project.DTOs.AdminDTOs;
using Library_Managment_Project.DTOs.LibarianDTOs;
using Library_Managment_Project.Interface;
using Library_Managment_Project.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Admin
    public class AdminController : ControllerBase
    {
        #region Variables+Constractor
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService) => _adminService = adminService;
        #endregion
        #region Update
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateAdminRequest adminRequest) => Ok(await _adminService.UpdateAsync(adminRequest));
        #endregion
    }
    #endregion
}
