using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Domain.Entities.Images
{
    public class Image
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public ImageVariant Original { get; set; }
        public ImageVariant Thumbnail { get; set; }
        public ImageVariant Small { get; set; }
        public ImageVariant Medium { get; set; }
        public ImageVariant Large { get; set; }
    }
}