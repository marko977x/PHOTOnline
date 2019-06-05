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
        public List<CartItem> CartItems { get; set; }
    }
}
