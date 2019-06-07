using Domain.Entities;
using PHOTOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.OrderManagement.Input
{
    public class PerformOrderInput
    {
        public string DeliveryAddress { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        public string CartId { get; set; }
    }
}
