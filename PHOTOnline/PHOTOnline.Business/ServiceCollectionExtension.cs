using Business.UserManagement;
using Microsoft.Extensions.DependencyInjection;
using PHOTOnline.Business.Files;
using PHOTOnline.Business.ProductManagement;

namespace PHOTOnline.Business
{
    public static class ServiceCollectionExtension
    {
        public static void AddPHOTOnlineBusinessServices(this IServiceCollection service)
        {
            service.AddScoped<IUserAccount, UserAccount>();
            service.AddScoped<IProductManager, ProductManager>();
            service.AddScoped<IFileUploader, FileUploader>();
        }
    }
}
