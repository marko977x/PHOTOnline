using Business.UserManagement;
using Microsoft.Extensions.DependencyInjection;
using PHOTOnline.Business.AlbumManagement;
using PHOTOnline.Business.CartManagement;
using PHOTOnline.Business.Files;
using PHOTOnline.Business.OrderManagement;
using PHOTOnline.Business.ProductManagement;
using PHOTOnline.Business.RequestManagement;
using PHOTOnline.Business.TaskManagement;

namespace PHOTOnline.Business
{
    public static class ServiceCollectionExtension
    {
        public static void AddPHOTOnlineBusinessServices(this IServiceCollection service)
        {
            service.AddScoped<IUserAccount, UserAccount>();
            service.AddScoped<IProductManager, ProductManager>();
            service.AddScoped<IFileUploader, FileUploader>();
            service.AddScoped<IAlbumManager, AlbumManager>();
            service.AddScoped<IOrderManager, OrderManager>();
            service.AddScoped<IRequestManager, RequestManager>();
            service.AddScoped<ITaskManager, TaskManager>();
            service.AddScoped<ICartManager, CartManager>();
        }
    }
}
