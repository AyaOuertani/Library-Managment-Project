using Library_Managment_Project.DTOs.UserDtos;
using Library_Managment_Project.Entities;
using Library_Managment_Project.Interface;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;
using Library_Managment_Project.Service;
using System.Security.Cryptography;
using Library_Managment_Project.Enum;

namespace Library_Managment_Project.Service
{
    public class UserService : IUserService
    {
        #region Variables+Constructor
        private readonly ApplicationDBcontext _dbcontext;
        public UserService(ApplicationDBcontext context)
        {
            _dbcontext = context;
        }
        #endregion

        #region SingUp
        public async Task<bool> SignUpAsync(PostSignUpInfoRequest request)
        {
            bool userExists;
            if (request.Role == Enum.UserRole.Librarian)
            {
                userExists = await _dbcontext.Librarian.AnyAsync(u => u.Email == request.Email);
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
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
                };

                _dbcontext.Librarian.Add(newLibrarian);
            }
            else if (request.Role == Enum.UserRole.Member)
            {
                userExists = await _dbcontext.Member.AnyAsync(u => u.Email == request.Email);
                if (userExists)
                {
                    return false;
                }
                Member newMember = new Member
                {
                    MemberCode = await GenerateUniqueMemberCodeAsync(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.PhoneNumber,
                    Role = request.Role,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
                };

                _dbcontext.Member.Add(newMember);
            }            
            else if (request.Role == Enum.UserRole.Admin)
            {
                userExists = await _dbcontext.Admin.AnyAsync(u => u.Email == request.Email);
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
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
                };
                _dbcontext.Admin.Add(newAdmin);
            }
            else
            {
                return false;
            }
            await _dbcontext.SaveChangesAsync();
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
                    Librarian? librarian = await _dbcontext.Librarian.FirstOrDefaultAsync(l => l.Email == request.Email);
                    if (librarian != null)
                    {
                        passwordIsValid = BCrypt.Net.BCrypt.Verify(request.Password, librarian.Password);
                    }
                    break;

                case UserRole.Admin:
                    Admin? admin = await _dbcontext.Admin.FirstOrDefaultAsync(a => a.Email == request.Email);
                    if (admin != null)
                    {
                        passwordIsValid = BCrypt.Net.BCrypt.Verify(request.Password, admin.Password);
                    }
                    break;

                case UserRole.Member:
                    Member? member = await _dbcontext.Member.FirstOrDefaultAsync(m => m.Email == request.Email);
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

        #region GenerateCodeMember
        public async Task<int> GenerateUniqueMemberCodeAsync()
        {
            int newMemberCode;
            bool isUnique = false;
            do
            {
                newMemberCode = GenerateRandomInt();
                isUnique = !await _dbcontext.Member.AnyAsync(u => u.MemberCode == newMemberCode);
            }
            while (!isUnique);

            return newMemberCode;
        }
        private int GenerateRandomInt()
        {
            byte[] buffer = new byte[8];
            RandomNumberGenerator.Fill(buffer);
            return Math.Abs(BitConverter.ToInt32(buffer, 0));
        }
        #endregion

    }
}
