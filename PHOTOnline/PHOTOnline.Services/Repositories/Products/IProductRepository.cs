using Domain.Entities;
using PhotoLine.Services.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Repositories.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllProductsOfTypeAsync(string type);
    }
}
