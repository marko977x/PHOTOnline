using Domain.Entities.Enums;
using System;

namespace Domain.Entities
{
    public class Request : IEntity
    {
        public string Id { get; set; }
        public string Notification { get; set; }
        public RequestStatus RequestStatus { get; set; }
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
