using PhotoLine.Domain.Interop;
using PHOTOnline.Business.Files.Input;
using PHOTOnline.Business.Files.Output;
using PHOTOnline.Domain.Entities;
using PHOTOnline.Services.Files;
using System.Threading.Tasks;

namespace PHOTOnline.Business.Files
{
    public class FileUploader : IFileUploader
    {
        private IImageService _imageService;

        public FileUploader(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<Result<UploadImageOutput>> UploadImageAsync(UploadImageInput input)
        {
            Image image = await _imageService.CreateImageAsync(
                input.LocalPath, input.OriginalFileName);

            return new Result<UploadImageOutput>()
            {
                Success = true,
                Data = new UploadImageOutput() { Image = image }
            };
        }
    }
}
