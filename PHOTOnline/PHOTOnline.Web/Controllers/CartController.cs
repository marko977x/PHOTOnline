using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.CartManagement;
using PHOTOnline.Business.CartManagement.Input;
using PHOTOnline.Domain.Entities;
using PHOTOnline.Services.Repositories.Carts;

namespace PHOTOnline.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class CartController : Controller
    {
        private ICartManager _cartManager;
        private ICartRepository _cartRepository;

        public CartController(
            ICartManager cartManager,
            ICartRepository cartRepository)
        {
            _cartManager = cartManager;
            _cartRepository = cartRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromForm]CreateCartInput input)
        {
            Result<string> result = await _cartManager.AddToCart(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem([FromForm]DeleteItemInput input)
        {
            Result result = await _cartManager.DeleteItem(
                input.CartId, input.CartItemId);

            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCart(string id)
        {
            Cart cart = await _cartRepository.FindAsync(id);
            if (cart == null)
            {
                return BadRequest(new Result() { Success = false });
            }
            else
            {
                return Ok(new Result<Cart>()
                {
                    Success = true,
                    Data = cart
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCartByUserId(string userId)
        {
            Cart cart = await _cartRepository.GetCartByUserId(userId);
            if (cart == null)
            {
                return BadRequest(new Result() { Success = false });
            }
            else
            {
                return Ok(new Result<Cart>()
                {
                    Success = true,
                    Data = cart
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart(string userId)
        {
            Result result = await _cartManager.ClearCart(userId);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }
    }
}