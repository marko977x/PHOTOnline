using Domain.Entities;
using MongoDB.Driver;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.ProductManagement.Input;
using PHOTOnline.Services.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Business.ProductManagement
{
    public class ProductManager : IProductManager
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<string>> AddShopProduct(ShopProductInput input)
        {
            Product product = new Product()
            {
                Title = input.Title,
                Price = input.Price,
                Description = input.Description,
                Size = input.Size,
                ProductCategory = input.ProductCategory,
                CategoryType = input.CategoryType,
                ImageBlobId = input.ImageBlobId
            };

            return new Result<string>()
            {
                Success = true,
                Data = await _productRepository.CreateAsync(product)
            };
        }
    }
}
