using Domain.Entities;
using PHOTOnline.Domain.Entities.Images;

namespace PHOTOnline.Domain.Entities
{
    public class CartItem : IEntity
    {
        public string Id { get; set; }
        public string ProductType { get; set; }
        public string Format { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public Image Image { get; set; }
    }
}
