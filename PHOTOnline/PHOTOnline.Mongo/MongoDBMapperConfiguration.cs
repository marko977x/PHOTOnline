using Domain.Entities;
using MongoDB.Bson.Serialization;

namespace PHOTOnline.Mongo
{
    public static class MongoDBMapperConfiguration
    {
        public static void RegisterMapping()
        {
            BsonClassMap.RegisterClassMap<Product>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<PHOTOnlineUser>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<Request>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<Task>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<Album>(cm =>
            {
                cm.AutoMap();
            });
            BsonClassMap.RegisterClassMap<Order>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
