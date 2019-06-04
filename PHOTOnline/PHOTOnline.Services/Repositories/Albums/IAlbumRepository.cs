using Domain.Entities;
using PhotoLine.Services.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace PHOTOnline.Services.Repositories.Albums
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<List<Album>> GetAllAlbums();
        Task<Album> GetAlbumByPassword(string password);
        Task DeleteImage(string albumId, string imageId);
    }
}
