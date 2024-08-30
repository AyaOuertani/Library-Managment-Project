using Library_Managment_Project.Interface;
using Library_Managment_Project.Service;
using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Library_Managment_Project.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IBooksService, BookService>()
                           .AddScoped<IMemberService, MemberService>()
                           .AddScoped<ILibrarianService, LibrarianService>()
                           .AddScoped<ILoanBookService, LoanBookService>()
                           .AddScoped<IUserService, UserService>()
                           .AddScoped<IAdminService, AdminService>();
        }

        private static int GenerateRandomInt()
        {
            byte[] buffer = new byte[8];
            RandomNumberGenerator.Fill(buffer);
            return Math.Abs(BitConverter.ToInt32(buffer, 0));
        }
        public static async Task<int> GenerateUniqueMemberCodeAsync(ApplicationDBcontext DbContext)
        {
            int newMemberCode;
            bool isUnique = false;
            do
            {
                newMemberCode = GenerateRandomInt();
                isUnique = !await DbContext.Member.AnyAsync(u => u.MemberCode == newMemberCode);
            }
            while (!isUnique);

            return newMemberCode;
        }



    }
}
