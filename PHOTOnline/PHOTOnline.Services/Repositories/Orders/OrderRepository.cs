using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using PHOTOnline.Mongo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Repositories.Orders
{
    public class OrderRepository : MongoRepository<Order>, IOrderRepository
    {
        public OrderRepository(
            MongoDatabase database,
            ILogger<MongoRepository<Order>> logger) : base(database, logger) { }

        public override string CollectionName => "Product";

        public async System.Threading.Tasks.Task DeleteCompleted()
        {
            var completed = Builders<Order>.Filter.Eq(
                order => order.RequestStatus, RequestStatus.Completed);
            await Collection.DeleteManyAsync(completed);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var matchAll = Builders<Order>.Filter.Empty;
            return await (await Collection.FindAsync(matchAll)).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserId(string userId)
        {
            var filter = Builders<Order>.Filter.Eq(order => order.UserId, userId);
            return await (await Collection.FindAsync(filter)).ToListAsync();
        }
    }
}
