using Microsoft.AspNetCore.Http;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.Files.Input;
using PHOTOnline.Business.Files.Output;
using System.Threading.Tasks;

namespace PHOTOnline.Business.Files
{
    public interface IFileUploader
    {
        Task<Result<UploadImageOutput>> UploadImageAsync(IFormFile input);
        Task<Result<UploadImageOutput>> UploadImageAsync(UploadImageInput input);
    }
}
