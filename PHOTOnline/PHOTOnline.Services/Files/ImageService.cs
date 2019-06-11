using PhotoLine.Domain.Interop;
using PHOTOnline.BlobStorage;
using PHOTOnline.Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System;
using System.Threading.Tasks;
using PHOTOnline.Services.Repositories.UploadedFiles;

namespace PHOTOnline.Services.Files
{
    public class ImageService : IImageService
    {
        private IBlobStore _blobStore;
        private IUploadedFilesRepository _uploadedFilesRepository;

        private const int THUMBNAIL_MAX = 200;
        private const int SMALL_MAX = 600;
        private const int MEDIUM_MAX = 1000;
        private const int LARGE_MAX = 1400;

        public ImageService(IBlobStore blobStore,
            IUploadedFilesRepository uploadedFilesRepository)
        {
            _blobStore = blobStore;
            _uploadedFilesRepository = uploadedFilesRepository;
        }

        public async Task<PHOTOnline.Domain.Entities.Images.Image> CreateImageAsync(
            string localPath, string contentType, string originalFileName)
        {
            ImageVariant originalVariant = await StoreImageVariant(
                localPath, contentType, originalFileName);

            ImageVariant thumbnailVariant = await CreateImageVariant(
                localPath, contentType, originalFileName, THUMBNAIL_MAX, 0, null);

            ImageVariant smallVariant = await CreateImageVariant(
                localPath, contentType, originalFileName, SMALL_MAX, THUMBNAIL_MAX, thumbnailVariant);

            ImageVariant mediumVariant = await CreateImageVariant(
                localPath, contentType, originalFileName, MEDIUM_MAX, SMALL_MAX, smallVariant);

            ImageVariant largeVariant = await CreateImageVariant(
                localPath, contentType, originalFileName, LARGE_MAX, MEDIUM_MAX, mediumVariant);

            return new Domain.Entities.Images.Image()
            {
                Original = originalVariant,
                Thumbnail = thumbnailVariant,
                Small = smallVariant,
                Medium = mediumVariant,
                Large = largeVariant,
                Title = originalFileName
            };
        }

        private async Task<ImageVariant> CreateImageVariant(
            string localPath, string contentType, string originalFileName,
            int maxWidth, int minWidth, ImageVariant smallerVariant)
        {
            string resizedImagePath = FitImageToSize(localPath, contentType, maxWidth, minWidth);
            if (resizedImagePath == null) return smallerVariant;

            return await StoreImageVariant(resizedImagePath, contentType, originalFileName);
        }

        private async Task<ImageVariant> StoreImageVariant(
            string imagePath, string contentType, string originalFileName)
        {
            Result<string> blobResult = await _blobStore
                .UploadFromFileAsync(imagePath, contentType);

            if (!blobResult.Success) return null;

            string fileId = await _uploadedFilesRepository.CreateAsync(new UploadedFile()
            {
                BlobId = blobResult.Data,
                ContentType = contentType,
                OriginalFileName = originalFileName
            });

            Result<string> urlResult = await _blobStore.GetReadUrlAsync(blobResult.Data);
            if (!urlResult.Success) return null;

            return new ImageVariant()
            {
                FileId = fileId,
                Url = urlResult.Data
            };
        }

        private string FitImageToSize(string imagePath,
            string contentType, int maxWidth, int minWidth)
        {
            Image<Rgba32> image = SixLabors.ImageSharp.Image.Load(imagePath);

            if (image.Width > maxWidth) return ResizeImage(image, contentType, maxWidth);

            if (image.Width > minWidth && image.Width <= maxWidth) return imagePath;

            return null;
        }

        private string ResizeImage(Image<Rgba32> image, string contentType, int maxWidth)
        {
            string filePath = Path.GetTempFileName();

            int maxHeight = maxWidth * image.Height / image.Width;
            image.Mutate(i => i.Resize(maxWidth, maxHeight));

            using (var stream = new FileStream(filePath, FileMode.Create))
                image.Save(stream, GetImageEncoder(contentType));

            return filePath;
        }

        private IImageEncoder GetImageEncoder(string contentType)
        {
            if (contentType == ContentTypes.PNG)
                return new PngEncoder();
            return new JpegEncoder();
        }
    }
}
