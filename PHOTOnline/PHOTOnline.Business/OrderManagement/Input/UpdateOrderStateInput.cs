using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.OrderManagement.Input
{
    public class UpdateOrderStateInput
    {
        public string OrderId { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public string Notification { get; set; }
    }
}
