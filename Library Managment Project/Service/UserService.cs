using Library_Managment_Project.DTOs.UserDtos;
using Library_Managment_Project.Entities;
using Library_Managment_Project.Interface;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;
using Library_Managment_Project.Service;
using System.Security.Cryptography;
using Library_Managment_Project.Enum;
using Library_Managment_Project.Extensions;

namespace Library_Managment_Project.Service
{
    public class UserService : IUserService
    {
        #region Variables+Constructor
        private readonly ApplicationDBcontext _dbContext;
        public UserService(ApplicationDBcontext context)
        {
            _dbContext = context;
        }
        #endregion

        #region SingUp
        public async Task<bool> SignUpAsync(PostSignUpInfoRequest request)
        {
            bool userExists;
            if (request.Role == Enum.UserRole.Librarian)
            {
                userExists = await _dbContext.Librarian.AnyAsync(u => u.Email == request.Email);
                if (userExists)
                {
                    return false;
                }
                Librarian newLibrarian = new Librarian
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.PhoneNumber,
                    Role = request.Role,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };

                _dbContext.Librarian.Add(newLibrarian);
            }
            else if (request.Role == Enum.UserRole.Member)
            {
                userExists = await _dbContext.Member.AnyAsync(u => u.Email == request.Email);
                if (userExists)
                {
                    return false;
                }
                Member newMember = new Member
                {
                    MemberCode = await DIExtension.GenerateUniqueMemberCodeAsync(_dbContext),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.PhoneNumber,
                    Role = request.Role,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                     CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };

                _dbContext.Member.Add(newMember);
            }            
            else if (request.Role == Enum.UserRole.Admin)
            {   if(await _dbContext.Admin.CountAsync()>0)
                    throw new System.Exception("There is already an admin");
                userExists = await _dbContext.Admin.AnyAsync(u => u.Email == request.Email);
                if (userExists)
                {
                    return false;
                }
                Admin newAdmin = new Admin
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.PhoneNumber,
                    Role = request.Role,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };
                _dbContext.Admin.Add(newAdmin);
            }
            else
            {
                return false;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region SignIn
        public async Task<bool> SignInAsync(PostSignInInfoRequest request)
        {
            bool passwordIsValid = false;

            switch (request.Role)
            {
                case UserRole.Librarian:
                    Librarian? librarian = await _dbContext.Librarian.FirstOrDefaultAsync(l => l.Email == request.Email);
                    if (librarian != null)
                    {
                        passwordIsValid = BCrypt.Net.BCrypt.Verify(request.Password, librarian.Password);
                    }
                    break;

                case UserRole.Admin:
                    Admin? admin = await _dbContext.Admin.FirstOrDefaultAsync(a => a.Email == request.Email);
                    if (admin != null)
                    {
                        passwordIsValid = BCrypt.Net.BCrypt.Verify(request.Password, admin.Password);
                    }
                    break;

                case UserRole.Member:
                    Member? member = await _dbContext.Member.FirstOrDefaultAsync(m => m.Email == request.Email);
                    if (member != null)
                    {
                        passwordIsValid = BCrypt.Net.BCrypt.Verify(request.Password, member.Password);
                    }
                    break;

                default:
                    return false;
            }

            return passwordIsValid;  
        }

        #endregion


    }
}
