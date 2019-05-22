using PHOTOnline.Domain.Entities;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Files
{
    public interface IImageService
    {
        Task<Image> CreateImageAsync(string localPath, string originalFileName);
    }
}
