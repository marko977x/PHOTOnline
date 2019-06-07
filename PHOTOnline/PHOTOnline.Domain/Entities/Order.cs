using Domain.Entities.Enums;
using PHOTOnline.Domain.Entities;

namespace Domain.Entities
{
    public class Order : IEntity
    {
        public string Id { get; set; }
        public string Notification { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public string DeliveryAddress { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        public string CartId { get; set; }
    }
}
