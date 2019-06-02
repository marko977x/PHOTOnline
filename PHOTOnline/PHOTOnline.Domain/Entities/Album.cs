using PHOTOnline.Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using System;
using System.Collections.Generic;

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
        public string Date { get; set; }
        public List<Image> Images { get; set; }
    }
}
