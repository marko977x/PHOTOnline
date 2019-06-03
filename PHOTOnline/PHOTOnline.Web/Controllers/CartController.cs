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
        private ICartManager _carManager;
        private ICartRepository _cartRepository;

        public CartController(
            ICartManager cartManager,
            ICartRepository cartRepository)
        {
            _carManager = cartManager;
            _cartRepository = cartRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromForm]CreateCartInput input)
        {
            Result<string> result = await _carManager.AddToCart(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(string cartId, string itemId)
        {
            Result result = await _carManager.DeleteItem(cartId, itemId);
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
    }
}