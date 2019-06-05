using Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using System.Collections.Generic;

namespace PHOTOnline.Domain.Entities
{
    public class Cart : IEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
