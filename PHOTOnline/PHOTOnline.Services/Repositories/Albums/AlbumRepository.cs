using Domain.Entities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using PHOTOnline.Mongo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Repositories.Albums
{
    public class AlbumRepository : MongoRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(
            MongoDatabase database,
            ILogger<MongoRepository<Album>> logger) : base(database, logger) { }

        public override string CollectionName => "Album";

        public async System.Threading.Tasks.Task DeleteImage(string albumId, string imageId)
        {
            Album album = await FindAsync(albumId);
            if (album != null)
            {
                album.Images.Remove(album.Images.Find(image => image.Id == imageId));
                await UpdateAsync(album);
            }
        }

        public async Task<Album> GetAlbumByPassword(string password)
        {
            var filter = Builders<Album>.Filter.Eq(
                album => album.Password, password);

            return await (await Collection.FindAsync(filter)).FirstOrDefaultAsync();
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            var all = Builders<Album>.Filter.Empty;
            return await (await Collection.FindAsync(all)).ToListAsync();
        }
    }
}
