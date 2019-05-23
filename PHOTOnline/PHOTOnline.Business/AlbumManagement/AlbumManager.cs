using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.AlbumManagement.Input;
using PHOTOnline.Services.Repositories.Albums;

namespace PHOTOnline.Business.AlbumManagement
{
    public class AlbumManager : IAlbumManager
    {
        private IAlbumRepository _albumRepository;

        public AlbumManager(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<Result<string>> AddAlbum(AddAlbumInput input)
        {
            Album album = new Album()
            {
                Date = input.Date,
                Description = input.Description,
                Images = input.Images,
                Location = input.Location,
                Organizer = input.Organizer,
                Password = input.Password,
                Title = input.Password
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
    }
}
