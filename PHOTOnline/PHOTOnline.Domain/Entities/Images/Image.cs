using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Domain.Entities.Images
{
    public class Image
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Original { get; set; }
        public string Thumbnail { get; set; }
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }
}