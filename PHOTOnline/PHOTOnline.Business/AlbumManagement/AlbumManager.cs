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
            //Delete images from cloud storage
            await _albumRepository.DeleteAsync(id);
            return new Result() { Success = true };
        }

        public async Task<Result> DeleteImage(DeleteImageInput input)
        {
            await _blobStore.DeleteBlobs(input.BlobsIds);
            await _albumRepository.DeleteImage(input.AlbumId, input.ImageId);
            return new Result() { Success = true };
        }
    }
}
