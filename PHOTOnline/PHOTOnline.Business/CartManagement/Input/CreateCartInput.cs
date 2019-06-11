using Domain.Entities;
using PHOTOnline.Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.CartManagement.Input
{
    public class CreateCartInput
    {
        public string UserId { get; set; }
        public List<CartItemInput> CartItems { get; set; }
    }

    public class CartItemInput
    {
        public string ProductType { get; set; }
        public Image Image { get; set; }
        public int Quantity { get; set; }
        public string Format { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
    }
}


