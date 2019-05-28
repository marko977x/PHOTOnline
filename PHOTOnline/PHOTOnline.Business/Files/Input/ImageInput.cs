using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.Files.Input
{
    public class ImageInput
    {
        public IFormFile File { get; set; }
        public string Param { get; set; }
    }
}
