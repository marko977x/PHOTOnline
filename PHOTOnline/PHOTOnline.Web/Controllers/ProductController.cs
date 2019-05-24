using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.ProductManagement;
using PHOTOnline.Business.ProductManagement.Input;
using PHOTOnline.Services.Repositories.Products;

namespace PHOTOnline.Web.Controllers
{
    [Route("/api/[controller]/[action]")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IProductManager _productManager;

        public ProductController(
            IProductRepository productRepository,
            IProductManager productManager)
        {
            _productRepository = productRepository;
            _productManager = productManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddShopProduct([FromBody]ShopProductInput input)
        {
            Result<string> result = await _productManager.AddShopProduct(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveShopProduct(string productId)
        {
            await _productRepository.DeleteAsync(productId);
            return Ok(new Result() { Success = true });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductData([FromBody]Product product)
        {
            await _productRepository.UpdateAsync(product);
            return Ok(new Result() { Success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsOfType(string productType)
        {
            return Ok(new Result<List<Product>>()
            {
                Success = true,
                Data = await _productRepository.GetAllProductsOfTypeAsync(productType)
            });
        }
    }
}