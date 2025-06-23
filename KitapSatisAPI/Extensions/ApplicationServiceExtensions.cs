using KitapSatisAPI.Repositories;
using KitapSatisAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KitapSatisAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
