using Library_Managment_Project.DTOs.UserDtos;
using Library_Managment_Project.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace Library_Managment_Project.Controllers
{
    #region User
    public class UserController : ControllerBase
    {
        #region Variables+Constractor
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;
        #endregion

        #region SignUp
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(PostSignUpInfoRequest request)
        {
          return !await _userService.SignUpAsync(request) ? Conflict("Email already exists.") : Ok("User signed up successfully.");
        }
        #endregion

        #region SignIn
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(PostSignInInfoRequest request)
        {
            return !await _userService.SignInAsync(request) ? Unauthorized("Invalid email or password.") : Ok("User signed in successfully.");
        }

        #endregion
    }
    #endregion
}
