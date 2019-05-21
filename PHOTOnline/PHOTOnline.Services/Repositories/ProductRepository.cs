using Domain.Entities;
using Microsoft.Extensions.Logging;
using PHOTOnline.Mongo;

namespace PHOTOnline.Services.Repositories
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        public ProductRepository(
            MongoDatabase database,
            ILogger<MongoRepository<Product>> logger) : base(database, logger) { }

        public override string CollectionName => "Product";
    }
}
