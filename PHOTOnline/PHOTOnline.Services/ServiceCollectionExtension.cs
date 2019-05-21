using Microsoft.Extensions.DependencyInjection;
using PHOTOnline.Services.Auth;
using PHOTOnline.Services.Repositories;

namespace PHOTOnline.Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddPHOTOnlineServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
