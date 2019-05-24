using Domain.Entities.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Product : IEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string ProductCategory { get; set; }
        public string CategoryType { get; set; }
        public string ImageBlobId { get; set; }
    }
}
