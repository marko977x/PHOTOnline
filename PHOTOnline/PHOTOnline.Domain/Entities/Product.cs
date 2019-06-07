namespace Domain.Entities
{
    public class Product : IEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string ProductType { get; set; }
        public string ImageUrl { get; set; }
    }
}
