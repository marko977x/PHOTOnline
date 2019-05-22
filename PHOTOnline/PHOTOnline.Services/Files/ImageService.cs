using PhotoLine.Domain.Interop;
using PHOTOnline.BlobStorage;
using PHOTOnline.Domain.Entities;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Files
{
    public class ImageService : IImageService
    {
        private IBlobStore _blobStore;

        public ImageService(IBlobStore blobStore)
        {
            _blobStore = blobStore;
        }

        public async Task<Image> CreateImageAsync(string localPath, string originalFileName)
        {
            Result<string> blobResult = await _blobStore
                .UploadFromFileAsync(localPath);

            if (!blobResult.Success) return null;

            Result<string> urlResult = await
                _blobStore.GetReadUrlAsync(blobResult.Data);

            if (!urlResult.Success) return null;

            return new Image()
            {
                BlobId = blobResult.Data,
                Title = originalFileName,
                Url = urlResult.Data
            };
        }
    }
}
