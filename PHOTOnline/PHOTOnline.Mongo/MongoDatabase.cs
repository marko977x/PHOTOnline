using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System.Security.Authentication;

namespace PHOTOnline.Mongo
{
    public class MongoDatabase
    {
        private IMongoDatabase _database;

        public MongoDatabase(IOptions<MongoOptions> options)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(options.Value.ConnectionString));

            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };

            ConventionPack pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true)
            };
            ConventionRegistry.Register("AffineApp Conventions", pack, t => true);

            var client = new MongoClient(settings);
            _database = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}