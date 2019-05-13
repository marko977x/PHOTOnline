using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Services.Repositories;

namespace PHOTOnline.Web.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _productRepository.CreateAsync(product);
            return Ok(new Result() { Success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetFirstProduct()
        {
            Result<Product> result = new Result<Product>();
            result.Data = await _productRepository.FindAsync("0");
            result.Success = true;
            return Ok(result);
        }
    }
}