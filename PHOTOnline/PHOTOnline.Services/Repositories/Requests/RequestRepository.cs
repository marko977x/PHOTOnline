using Domain.Entities;
using Microsoft.Extensions.Logging;
using PHOTOnline.Mongo;

namespace PHOTOnline.Services.Repositories.Requests
{
    public class RequestRepository : MongoRepository<Request>, IRequestRepository
    {
        public RequestRepository(
            MongoDatabase database,
            ILogger<MongoRepository<Request>> logger) : base(database, logger) { }

        public override string CollectionName => "Request";
    }
}
