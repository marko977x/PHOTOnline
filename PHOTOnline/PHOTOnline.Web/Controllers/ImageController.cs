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
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IFileUploader _fileUploader;

        public ImageController(IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest();

            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(stream);

            UploadImageInput input = new UploadImageInput()
            {
                OriginalFileName = file.FileName,
                LocalPath = filePath
            };

            Result<UploadImageOutput> result =
                await _fileUploader.UploadImageAsync(input);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}