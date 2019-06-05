using Domain.Entities;
using Microsoft.Extensions.Logging;
using PHOTOnline.Domain.Entities.Images;
using PHOTOnline.Mongo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Services.Repositories.UploadedFiles
{
    public class UploadedFilesRepository : MongoRepository<UploadedFile>, IUploadedFilesRepository
    {
        public UploadedFilesRepository(
            MongoDatabase database,
            ILogger<MongoRepository<UploadedFile>> logger) : base(database, logger) { }

        public override string CollectionName => "uploadedFiles";
    }
}
