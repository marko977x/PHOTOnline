﻿using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.CartManagement.Input;
using PHOTOnline.Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using PHOTOnline.Services.Repositories.Carts;
using PHOTOnline.Services.Repositories.UploadedFiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Business.CartManagement
{
    public class CartManager : ICartManager
    {
        private ICartRepository _cartRepository;
        private IUploadedFilesRepository _uploadedFilesRepository;

        public CartManager(
            ICartRepository cartRepository,
            IUploadedFilesRepository uploadedFilesRepository)
        {
            _cartRepository = cartRepository;
            _uploadedFilesRepository = uploadedFilesRepository;
        }

        public async Task<Result<string>> AddToCart(CreateCartInput input)
        {
            Cart cart = await _cartRepository.GetCartByUserId(input.UserId);

            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = input.UserId,
                    CartItems = input.CartItems
                };

                return new Result<string>()
                {
                    Success = true,
                    Data = await _cartRepository.CreateAsync(cart)
                };
            }
            else
            {
                input.CartItems.ForEach(item => cart.CartItems.Add(item));

                await _cartRepository.UpdateAsync(cart);

                return new Result<string>()
                {
                    Success = true,
                    Data = cart.Id
                };
            }
        }

        public async Task<Result> DeleteItem(string cartId, string cartItemId)
        {
            Cart cart = await _cartRepository.FindAsync(cartId);
            if (cart == null)
            {
                return new Result()
                {
                    Success = false
                };
            }

            CartItem cartItem = cart.CartItems.Find(item => item.Id == cartItemId);

            if (cartItem != null)
            {
                await _uploadedFilesRepository.DeleteAsync(cartItem.Image.Id);
                cart.CartItems.Remove(cartItem);
            }

            return new Result()
            {
                Success = true
            };
        }
    }
}