using Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Domain.Entities
{
    public class CartItem : IEntity
    {
        public string Id { get; set; }
        public Image Image { get; set; }
        public string ProductType { get; set; }
    }
}
