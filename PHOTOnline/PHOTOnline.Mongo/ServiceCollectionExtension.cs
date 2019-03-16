﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PHOTOnline.Mongo
{
    public static class ServiceCollectionExtension
    {
        private const string MONGO_SECTION = "Mongo";

        public static void AddMongoDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoDatabase>();
            services.Configure<MongoOptions>(configuration.GetSection(MONGO_SECTION));
        }
    }
}