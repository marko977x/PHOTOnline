using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.RequestManagement.Input
{
    public class CreateRequestInput
    {
        public string EventType { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string AdditionalRequests { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Time { get; set; }
    }
}
