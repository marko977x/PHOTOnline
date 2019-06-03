using Domain.Entities;
using PHOTOnline.Domain.Entities.Images;
using MongoDB.Bson.Serialization;
using PHOTOnline.Domain.Entities;

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
            BsonClassMap.RegisterClassMap<Image>(cm =>
            {
                cm.AutoMap();
            });
            BsonClassMap.RegisterClassMap<Cart>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
