using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.Files;
using PHOTOnline.Business.Files.Input;
using PHOTOnline.Business.Files.Output;

namespace PHOTOnline.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class ImageController : Controller
    {
        private IFileUploader _fileUploader;

        public ImageController(IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
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
        public async Task<IActionResult> UploadImages(List<IFormFile> images)
        {
            Result<List<UploadImageOutput>> results = new Result<List<UploadImageOutput>>() { Success = true };
            images.ForEach(async image =>
            {
                Result<UploadImageOutput> result = await _fileUploader.UploadImageAsync(image);
                results.Data.Add(result.Data);
            });

            if (results.Success)
                return Ok(results);
            else
                return BadRequest(results);
        }

    }
}