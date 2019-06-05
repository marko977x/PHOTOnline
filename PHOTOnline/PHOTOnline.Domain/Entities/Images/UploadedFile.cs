using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Domain.Entities.Images
{
    public class UploadedFile : IEntity
    {
        public string Id { get; set; }
        public string BlobId { get; set; }
        public string ContentType { get; set; }
        public string OriginalFileName { get; set; }
    }
}
