using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.AlbumManagement.Input
{
    public class DeleteImageInput
    {
        public string AlbumId { get; set; }
        public string ImageId { get; set; }
        public List<string> BlobsIds { get; set; }
    }
}
