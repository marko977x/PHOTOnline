using System;

namespace Domain.Entities
{
    public class Album : IEntity
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
