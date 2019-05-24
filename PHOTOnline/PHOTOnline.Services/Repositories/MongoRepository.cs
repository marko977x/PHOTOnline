using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using PHOTOnline.Mongo;
using System;
using System.Threading.Tasks;
using System.Linq;
using Domain.Entities;
using Task = System.Threading.Tasks.Task;
using System.Collections.Generic;

namespace PHOTOnline.Services.Repositories
{
    public abstract class MongoRepository<T> where T : IEntity
    {
        public abstract string CollectionName { get; }

        private MongoDatabase _database;
        protected ILogger<MongoRepository<T>> _logger;
        private IMongoCollection<T> _collection;
        protected IMongoCollection<T> Collection
        {
            get
            {
                if (_collection == null)
                    _collection = _database.GetCollection<T>(CollectionName);
                return _collection;
            }
        }

        public MongoRepository(MongoDatabase database, ILogger<MongoRepository<T>> logger)
        {
            _database = database;
            _logger = logger;
        }

        public async Task<T> FindAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq(entity => entity.Id, id);
            T result = (await Collection.FindAsync(filter)).FirstOrDefault();
            if (result == null)
                _logger.LogWarning($"FindAsync: could not find object (Id = \"{id}\") in {CollectionName}");
            return result;
        }

        public async Task<string> CreateAsync(T entity)
        {
            if (entity.Id == null) entity.Id = Guid.NewGuid().ToString();
            await Collection.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq(en => en.Id, entity.Id);
            await Collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq(entity => entity.Id, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<T>> GetAll()
        {
            var filter = Builders<T>.Filter.Empty;
            return await (await Collection.FindAsync(filter)).ToListAsync();
        }
    }
}
