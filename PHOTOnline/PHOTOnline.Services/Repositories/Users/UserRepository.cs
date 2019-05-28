using Domain.Entities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using PHOTOnline.Domain.Entities.Enums;
using PHOTOnline.Mongo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Repositories.Users
{
    public class UserRepository : MongoRepository<PHOTOnlineUser>, IUserRepository
    {
        public UserRepository(
            MongoDatabase database,
            ILogger<MongoRepository<PHOTOnlineUser>> logger) : base(database, logger) { }
        public override string CollectionName => "users";

        public async Task<List<PHOTOnlineUser>> GetAllPhotographs()
        {
            var filter = Builders<PHOTOnlineUser>.Filter.Eq(
                user => user.UserType, UserType.Photograph);
            return await (await Collection.FindAsync(filter)).ToListAsync();
        }

        public async Task<List<PHOTOnlineUser>> GetAllUsers()
        {
            var filter = Builders<PHOTOnlineUser>.Filter.Empty;
            return await (await Collection.FindAsync(filter)).ToListAsync();
        }
    }
}
