using Domain.Entities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using PHOTOnline.Mongo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Services.Repositories.Tasks
{
    public class TaskRepository : MongoRepository<Task>, ITaskRepository
    {
        public TaskRepository(
            MongoDatabase database,
            ILogger<MongoRepository<Task>> logger) : base(database, logger) { }

        public override string CollectionName => "Task";

        public async System.Threading.Tasks.Task<List<Task>> GetAllTasksByUserId(string id)
        {
            var filter = Builders<Task>.Filter.Eq(task => task.Id, id);
            return await (await Collection.FindAsync(filter)).ToListAsync();
        }
    }
}
