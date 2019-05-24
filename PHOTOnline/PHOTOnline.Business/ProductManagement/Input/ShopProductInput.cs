using Domain.Entities.Enums;

namespace PHOTOnline.Business.ProductManagement.Input
{
    public class ShopProductInput
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string ProductCategory { get; set; }
        public string CategoryType { get; set; }
        public string ImageBlobId { get; set; }
    }
}
