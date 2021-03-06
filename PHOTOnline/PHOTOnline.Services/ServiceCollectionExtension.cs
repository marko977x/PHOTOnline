﻿using Microsoft.Extensions.DependencyInjection;
using PHOTOnline.Services.Auth;
using PHOTOnline.Services.Files;
using PHOTOnline.Services.Repositories.Albums;
using PHOTOnline.Services.Repositories.Carts;
using PHOTOnline.Services.Repositories.Orders;
using PHOTOnline.Services.Repositories.Products;
using PHOTOnline.Services.Repositories.Requests;
using PHOTOnline.Services.Repositories.Tasks;
using PHOTOnline.Services.Repositories.UploadedFiles;
using PHOTOnline.Services.Repositories.Users;

namespace PHOTOnline.Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddPHOTOnlineServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IAlbumRepository, AlbumRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IRequestRepository, RequestRepository>();
            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddSingleton<IUploadedFilesRepository, UploadedFilesRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
        }
    }
}
