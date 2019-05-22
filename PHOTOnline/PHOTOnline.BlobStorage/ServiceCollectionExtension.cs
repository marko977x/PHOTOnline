using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PHOTOnline.BlobStorage
{
    public static class ServiceCollectionExtension
    {
        private const string BLOB_STORAGE_SECTION = "BlobStorage";
        public static void AddBlobStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBlobStore, BlobStore>();
            services.Configure<BlobStoreOptions>(configuration.GetSection(BLOB_STORAGE_SECTION));
        }
    }
}
