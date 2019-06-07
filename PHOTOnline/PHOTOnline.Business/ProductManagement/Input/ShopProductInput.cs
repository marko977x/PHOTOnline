using Domain.Entities.Enums;
using PHOTOnline.Domain.Entities.Images;

namespace PHOTOnline.Business.ProductManagement.Input
{
    public class ShopProductInput
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string ProductType { get; set; }
    }
}
