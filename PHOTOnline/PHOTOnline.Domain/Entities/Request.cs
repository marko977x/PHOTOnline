using Domain.Entities.Enums;
using System;

namespace Domain.Entities
{
    public class Request : IEntity
    {
        public string Id { get; set; }
        public string Notification { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public RequestType RequestType { get; set; }
        public EventType EventType { get; set; }
        public string DeliveryAddress { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public string AdditionalRequests { get; set; }
        public string UserId { get; set; }
    }
}
