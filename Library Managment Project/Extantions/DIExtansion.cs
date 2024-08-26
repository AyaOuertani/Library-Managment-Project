using Library_Managment_Project.Interface;
using Library_Managment_Project.Service;

namespace Library_Managment_Project.Extantions
{
    public static class DIExtansion
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IBooksService, BookService>()
                           .AddScoped<IMemberService, MemberService>();
        }

    }
}
