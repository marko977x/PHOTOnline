using PHOTOnline.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PHOTOnline.Business.AlbumManagement.Input
{
    public class AddAlbumInput
    {
        public string Password { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public List<Image> Images { get; set; }
    }
}
