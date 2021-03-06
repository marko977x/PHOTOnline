﻿using PHOTOnline.Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Files
{
    public interface IImageService
    {
        Task<Image> CreateImageAsync(string localPath,
            string contentType, string originalFileName);
    }
}
