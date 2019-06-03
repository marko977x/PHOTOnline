using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using PHOTOnline.Domain.Entities;
using PHOTOnline.Mongo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Repositories.Carts
{
    public class CartRepository : MongoRepository<Cart>, ICartRepository
    {
        public override string CollectionName => "Cart";

        public CartRepository(
            MongoDatabase database,
            ILogger<MongoRepository<Cart>> logger) : base(database, logger) { }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            var filter = Builders<Cart>.Filter.Eq(cart => cart.UserId, userId);
            return (await Collection.FindAsync(filter)).FirstOrDefault();
        }
    }
}
