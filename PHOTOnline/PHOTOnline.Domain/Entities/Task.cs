using Domain.Entities.Enums;
using System;

namespace Domain.Entities
{
    public class Task : IEntity
    {
        public string Id { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
        public string PhotographId { get; set; }
        public EventType EventType { get; set; }
    }
}
