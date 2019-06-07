using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.CartManagement.Input
{
    public class DeleteItemInput
    {
        public string CartId { get; set; }
        public string CartItemId { get; set; }
    }
}
