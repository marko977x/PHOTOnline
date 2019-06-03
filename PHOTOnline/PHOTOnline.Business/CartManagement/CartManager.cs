using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.CartManagement.Input;
using PHOTOnline.Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using PHOTOnline.Services.Repositories.Carts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Business.CartManagement
{
    public class CartManager : ICartManager
    {
        private ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<string>> AddToCart(CreateCartInput input)
        {
            Cart cart = await _cartRepository.GetCartByUserId(input.UserId);

            if (cart == null)
            {
                cart = new Cart()
                {
                    Images = input.Images,
                    Products = input.Products,
                    UserId = input.UserId
                };

                return new Result<string>()
                {
                    Success = true,
                    Data = await _cartRepository.CreateAsync(cart)
                };
            }
            else
            {
                input.Images.ForEach(image => cart.Images.Add(image));
                input.Products.ForEach(product => cart.Products.Add(product));

                await _cartRepository.UpdateAsync(cart);

                return new Result<string>()
                {
                    Success = true,
                    Data = cart.Id
                };
            }
        }

        public async Task<Result> DeleteItem(string cartId, string itemId)
        {
            Cart cart = await _cartRepository.FindAsync(cartId);
            if (cart == null)
            {
                return new Result()
                {
                    Success = false
                };
            }

            Image image = cart.Images.Find(item => item.Id == itemId);

            if (image == null)
            {
                Product product = cart.Products.Find(item => item.Id == itemId);
                if (product == null)
                {
                    return new Result()
                    {
                        Success = false
                    };
                }
                else
                {
                    cart.Products.Remove(product);
                }
            }
            else
            {
                cart.Images.Remove(image);
            }

            return new Result()
            {
                Success = true
            };
        }
    }
}
