using System;
using System.Collections.Generic;

namespace PHOTOnline.Business.AlbumManagement.Input
{
    public class AddAlbumInput
    {
        public string Password { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<string> Images { get; set; }
    }
}
