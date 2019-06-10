using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using PhotoLine.Domain.Errors;
using PhotoLine.Domain.Interop;
using PHOTOnline.BlobStorage;
using PHOTOnline.Business.AlbumManagement.Input;
using PHOTOnline.Domain.Entities.Images;
using PHOTOnline.Services.Repositories.Albums;
using PHOTOnline.Services.Repositories.UploadedFiles;
using Task = System.Threading.Tasks.Task;

namespace PHOTOnline.Business.AlbumManagement
{
    public class AlbumManager : IAlbumManager
    {
        private IAlbumRepository _albumRepository;
        private IBlobStore _blobStore;
        private IUploadedFilesRepository _uploadedFilesRepository;

        public AlbumManager(
            IAlbumRepository albumRepository,
            IBlobStore blobStore,
            IUploadedFilesRepository uploadedFilesRepository)
        {
            _albumRepository = albumRepository;
            _blobStore = blobStore;
            _uploadedFilesRepository = uploadedFilesRepository;
        }

        public async Task<Result<string>> AddAlbum(AddAlbumInput input)
        {
            Album album = new Album()
            {
                Images = input.Images,
                Location = input.Location,
                Password = input.Password,
                Title = input.Title,
                Date = input.Date
            };

            return new Result<string>()
            {
                Success = true,
                Data = await _albumRepository.CreateAsync(album)
            };
        }

        public async Task<Result> DeleteAlbum(string id)
        {
            Album album = await _albumRepository.FindAsync(id);
            List<string> imageVariantsIds = new List<string>();
            List<UploadedFile> uploadedFiles = new List<UploadedFile>();

            if (album.Images != null)
            {
                album.Images.ForEach(image =>
                {
                    imageVariantsIds.AddRange(GetImageVariantsIds(image));
                });

                uploadedFiles = await _uploadedFilesRepository.
                DeleteUploadedFiles(imageVariantsIds);

                await _blobStore.DeleteBlobs(GetBlobsIds(uploadedFiles));
            }

            await _albumRepository.DeleteAsync(id);
            return new Result() { Success = true };
        }

        public async Task<Result> DeleteImage(DeleteImageInput input)
        {
            Album album = await _albumRepository.FindAsync(input.AlbumId);
            Image result = album.Images.Find(image => image.Id.Equals(input.ImageId));

            List<UploadedFile> uploadedFiles = await _uploadedFilesRepository
                .DeleteUploadedFiles(GetImageVariantsIds(result));

            await _blobStore.DeleteBlobs(GetBlobsIds(uploadedFiles));
            await _albumRepository.DeleteImage(input.AlbumId, input.ImageId);
            return new Result() { Success = true };
        }


        private List<string> GetBlobsIds(List<UploadedFile> files)
        {
            List<string> blobsIds = new List<string>();
            files.ForEach(file => blobsIds.Add(file.BlobId));
            return blobsIds;
        }

        public List<string> GetImageVariantsIds(Image image)
        {
            List<string> result = new List<string>
            {
                image.Large.FileId,
                image.Medium.FileId,
                image.Small.FileId,
                image.Original.FileId,
                image.Thumbnail.FileId,
            };
            return result;
        }

        public async Task<Result> AddImagesToAlbum(AddImagesToAlbumInput input)
        {
            Album album = await _albumRepository.FindAsync(input.AlbumId);
            if (album == null)
            {
                return new Result()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.AlbumNotFound) }
                };
            }

            album.Images.AddRange(input.Images);
            await _albumRepository.UpdateAsync(album);
            return new Result() { Success = true };
        }

        public async Task<Result> DeleteImage(Image image)
        {
            List<UploadedFile> uploadedFiles = await _uploadedFilesRepository
                .DeleteUploadedFiles(GetImageVariantsIds(image));

            await _blobStore.DeleteBlobs(GetBlobsIds(uploadedFiles));
            return new Result() { Success = true };
        }
    }
}
