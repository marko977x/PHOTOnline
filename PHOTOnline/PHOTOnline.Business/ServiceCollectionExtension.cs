using Business.UserManagement;
using Microsoft.Extensions.DependencyInjection;

namespace PHOTOnline.Business
{
    public static class ServiceCollectionExtension
    {
        public static void AddPHOTOnlineBusinessServices(this IServiceCollection service)
        {
            service.AddScoped<IUserAccount, UserAccount>();
        }
    }
}
