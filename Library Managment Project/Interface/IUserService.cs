using Library_Managment_Project.DTOs.UserDtos;

namespace Library_Managment_Project.Interface
{
    public interface IUserService
    {
        public Task<bool> SignUpAsync (PostSignUpInfoRequest request);
        public Task<bool> SignInAsync (PostSignInInfoRequest request);
    }
}
