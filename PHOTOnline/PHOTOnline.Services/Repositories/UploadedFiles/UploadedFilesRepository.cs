using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using PHOTOnline.Domain.Entities.Images;
using PHOTOnline.Mongo;

namespace PHOTOnline.Services.Repositories.UploadedFiles
{
    public class UploadedFilesRepository : MongoRepository<UploadedFile>, IUploadedFilesRepository
    {
        public UploadedFilesRepository(
            MongoDatabase database,
            ILogger<MongoRepository<UploadedFile>> logger) : base(database, logger) { }

        public override string CollectionName => "uploadedFiles";

        public async Task<List<UploadedFile>> DeleteUploadedFiles(List<string> ids)
        {
            var filter = Builders<UploadedFile>.Filter.In(file => file.Id, ids);
            List<UploadedFile> files = await
                (await Collection.FindAsync(filter)).ToListAsync();

            await Collection.DeleteManyAsync(filter);
            return files;
        }
    }
}
