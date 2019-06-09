using Domain.Entities.Enums;
using PHOTOnline.Domain.Entities;
using System.Collections.Generic;

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
        public List<CartItem> CartItems { get; set; }
        public float Price { get; set; }
    }
}
