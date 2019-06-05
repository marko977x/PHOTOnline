using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.BlobStorage;
using PHOTOnline.Business.AlbumManagement.Input;
using PHOTOnline.Domain.Entities.Images;
using PHOTOnline.Services.Repositories.Albums;

namespace PHOTOnline.Business.AlbumManagement
{
    public class AlbumManager : IAlbumManager
    {
        private IAlbumRepository _albumRepository;
        private IBlobStore _blobStore;

        public AlbumManager(
            IAlbumRepository albumRepository,
            IBlobStore blobStore)
        {
            _albumRepository = albumRepository;
            _blobStore = blobStore;
        }

        public async Task<Result<string>> AddAlbum(AddAlbumInput input)
        {
            Album album = new Album()
            {
                Images = input.Images,
                Location = input.Location,
                Password = input.Password,
                Title = input.Title
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
            List<string> blobsIds = new List<string>();

            album.Images.ForEach(image =>
            {
                blobsIds.Add(image.Large.FileId);
                blobsIds.Add(image.Medium.FileId);
                blobsIds.Add(image.Small.FileId);
                blobsIds.Add(image.Original.FileId);
                blobsIds.Add(image.Thumbnail.FileId);
            });

            await _blobStore.DeleteBlobs(blobsIds);
            await _albumRepository.DeleteAsync(id);
            return new Result() { Success = true };
        }

        public async Task<Result> DeleteImage(DeleteImageInput input)
        {
            Album album = await _albumRepository.FindAsync(input.AlbumId);

            Image result = album.Images.Find(image => image.Id.Equals(input.ImageId));

            await _blobStore.DeleteBlobs(GetBlobsIdsFromImage(result));
            await _albumRepository.DeleteImage(input.AlbumId, input.ImageId);
            return new Result() { Success = true };
        }

        private List<string> GetBlobsIdsFromImage(Image image)
        {
            List<string> blobsIds = new List<string>
            {
                image.Large.FileId,
                image.Medium.FileId,
                image.Small.FileId,
                image.Original.FileId,
                image.Thumbnail.FileId
            };
            return blobsIds;
        }
    }
}
