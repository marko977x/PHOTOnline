﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.BlobStorage;
using PHOTOnline.Business.AlbumManagement;
using PHOTOnline.Business.AlbumManagement.Input;
using PHOTOnline.Business.Files;
using PHOTOnline.Business.Files.Input;
using PHOTOnline.Business.Files.Output;
using PHOTOnline.Domain.Entities.Images;

namespace PHOTOnline.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class ImageController : Controller
    {
        private IFileUploader _fileUploader;
        private IBlobStore _blobStore;
        private IAlbumManager _albumManager;

        public ImageController(
            IFileUploader fileUploader,
            IBlobStore blobStore,
            IAlbumManager albumManager)
        {
            _fileUploader = fileUploader;
            _blobStore = blobStore;
            _albumManager = albumManager;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0) return BadRequest();

            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
                await image.CopyToAsync(stream);

            UploadImageInput input = new UploadImageInput()
            {
                OriginalFileName = image.FileName,
                ContentType = image.ContentType,
                LocalPath = filePath
            };

            Result<UploadImageOutput> result =
                await _fileUploader.UploadImageAsync(input);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage([FromForm]DeleteImageInput input)
        {
            Result result = await _albumManager.DeleteImage(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImageOutisdeAlbum([FromForm]Image image)
        {
            Result result = await _albumManager.DeleteImage(image);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

    }
}