using Domain.Entities;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order : IEntity
    {
        public string Id { get; set; }
        public string Notification { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public string DeliveryAddress { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
