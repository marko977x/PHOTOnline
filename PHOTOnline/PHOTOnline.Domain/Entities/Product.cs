using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Product : IEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string RequestId { get; set; }
        public string AlbumId { get; set; }
        public ProductType ProductType { get; set; }
        public CoverType CoverType { get; set; }
        public CalendarType CalendarType { get; set; }
        public MugType MugType { get; set; }
    }
}
