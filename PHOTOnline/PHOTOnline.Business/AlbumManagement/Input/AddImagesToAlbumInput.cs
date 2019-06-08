using PHOTOnline.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.AlbumManagement.Input
{
    public class AddImagesToAlbumInput
    {
        public string AlbumId { get; set; }
        public List<Image> Images { get; set; }
    }
}
