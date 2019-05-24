using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using PHOTOnline.Mongo;

namespace PHOTOnline.Services.Repositories.Requests
{
    public class RequestRepository : MongoRepository<Request>, IRequestRepository
    {
        public RequestRepository(
            MongoDatabase database,
            ILogger<MongoRepository<Request>> logger) : base(database, logger) { }

        public override string CollectionName => "Request";

        public async System.Threading.Tasks.Task DeleteResolvedRequests()
        {
            var query = Builders<Request>.Filter.Eq(
                request => request.RequestStatus, RequestStatus.Completed);
            await Collection.DeleteManyAsync(query);
        }

        public async Task<List<Request>> GetAllRequests()
        {
            var matchAll = Builders<Request>.Filter.Empty;
            return await (await Collection.FindAsync(matchAll)).ToListAsync();
        }

        public async Task<List<Request>> GetRequestsByUserId(string id)
        {
            var query = Builders<Request>.Filter.Eq(request => request.UserId, id);
            return await (await Collection.FindAsync(query)).ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateRequestStatus(string requestId, RequestStatus requestStatus)
        {
            var filter = Builders<Request>.Filter.Eq(request => request.Id, requestId);
            var update = Builders<Request>.Update.Set("RequestStatus", requestStatus);

            await Collection.FindOneAndUpdateAsync(filter, update);
        }
    }
}
