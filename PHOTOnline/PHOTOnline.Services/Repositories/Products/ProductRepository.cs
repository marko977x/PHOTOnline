using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using PHOTOnline.Mongo;

namespace PHOTOnline.Services.Repositories.Products
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        public ProductRepository(
            MongoDatabase database,
            ILogger<MongoRepository<Product>> logger) : base(database, logger) { }

        public override string CollectionName => "Product";

        public async Task<List<Product>> GetAllProductsOfTypeAsync(string type)
        {
            var filter = Builders<Product>.Filter.Eq(
                product => product.ProductCategory, type);
            return await (await Collection.FindAsync(filter)).ToListAsync();
        }
    }
}
