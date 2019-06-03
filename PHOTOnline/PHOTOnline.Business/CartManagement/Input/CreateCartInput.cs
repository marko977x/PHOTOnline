using Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.CartManagement.Input
{
    public class CreateCartInput
    {
        public string UserId { get; set; }
        public List<Image> Images { get; set; }
        public List<Product> Products { get; set; }
    }
}
