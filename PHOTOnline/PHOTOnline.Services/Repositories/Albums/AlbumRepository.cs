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

        public async Task<List<Album>> GetAllAlbums()
        {
            var all = Builders<Album>.Filter.Empty;
            return await (await Collection.FindAsync(all)).ToListAsync();
        }
    }
}
