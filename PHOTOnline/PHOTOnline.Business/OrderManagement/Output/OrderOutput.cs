using Domain.Entities;

namespace PHOTOnline.Business.OrderManagement.Output
{
    public class OrderOutput
    {
        public Order Order { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
