using PHOTOnline.Domain.Entities;
using System.Collections.Generic;

namespace PHOTOnline.Business.OrderManagement.Input
{
    public class PerformOrderInput
    {
        public string DeliveryAddress { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        public List<CartItem> CartItems { get; set; }
        public string Price { get; set; }
    }
}
