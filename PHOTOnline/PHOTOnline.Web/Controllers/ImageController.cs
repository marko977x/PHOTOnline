using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
        public async Task<IActionResult> UploadImage(ImageInput input)
        {
            if (input.File == null || input.File.Length == 0) return BadRequest("NULL / ZERO");

            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
                await input.File.CopyToAsync(stream);

            UploadImageInput uploadImageInput = new UploadImageInput()
            {
                OriginalFileName = input.File.FileName,
                LocalPath = filePath
            };

            Result<UploadImageOutput> result =
                await _fileUploader.UploadImageAsync(uploadImageInput);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages(List<ImageInput> images)
        {
            Result<List<UploadImageOutput>> results = new Result<List<UploadImageOutput>>();
            foreach (ImageInput image in images)
            {
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                    await image.File.CopyToAsync(stream);

                UploadImageInput uploadImageInput = new UploadImageInput()
                {
                    OriginalFileName = image.File.FileName,
                    LocalPath = filePath
                };

                Result<UploadImageOutput> result =
                    await _fileUploader.UploadImageAsync(uploadImageInput);
                if (result.Success) results.Data.Add(result.Data);
                else return BadRequest(new Result() { Success = false });
            }
            return Ok(results);
        }
    }
}