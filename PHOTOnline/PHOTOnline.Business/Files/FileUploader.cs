using Microsoft.AspNetCore.Http;
using PhotoLine.Domain.Errors;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.Files.Input;
using PHOTOnline.Business.Files.Output;
using PHOTOnline.Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using PHOTOnline.Services.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PHOTOnline.Business.Files
{
    public class FileUploader : IFileUploader
    {
        private IImageService _imageService;
        private readonly List<string> _allowedContentTypes;

        public FileUploader(IImageService imageService)
        {
            _imageService = imageService;

            _allowedContentTypes = new List<string>()
            {
                ContentTypes.JPEG,
                ContentTypes.PNG
            };
        }

        public async Task<Result<UploadImageOutput>> UploadImageAsync(UploadImageInput input)
        {
            if (!IsContentTypeValid(input.ContentType))
                return new Result<UploadImageOutput>()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.UnacceptableContentType) }
                };

            Image image = await _imageService.CreateImageAsync(
                input.LocalPath, input.ContentType, input.OriginalFileName);

            image.Id = Guid.NewGuid().ToString();
            return new Result<UploadImageOutput>()
            {
                Success = true,
                Data = new UploadImageOutput() { Image = image }
            };
        }

        private bool IsContentTypeValid(string contentType)
        {
            return _allowedContentTypes.Contains(contentType);
        }

        public async Task<Result<UploadImageOutput>> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0) return null;

            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
                await image.CopyToAsync(stream);

            UploadImageInput input = new UploadImageInput()
            {
                OriginalFileName = image.FileName,
                ContentType = image.ContentType,
                LocalPath = filePath
            };

            return await UploadImageAsync(input);
        }
    }
}
