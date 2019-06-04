using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PhotoLine.Domain.Interop;
using PHOTOnline.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PHOTOnline.BlobStorage
{
    public class BlobStore : IBlobStore
    {
        private IOptions<BlobStoreOptions> _options;
        private ILogger<BlobStore> _logger;

        public BlobStore(
            IOptions<BlobStoreOptions> options,
            ILogger<BlobStore> logger)
        {
            _options = options;
            _logger = logger;
        }

        private CloudStorageAccount _storageAccount;
        private CloudStorageAccount StorageAccount
        {
            get
            {
                if (_storageAccount == null)
                {
                    CloudStorageAccount.TryParse(
                        _options.Value.ConnectionString, out _storageAccount);
                }
                return _storageAccount;
            }
        }

        private CloudBlobContainer _container;
        private async Task<CloudBlobContainer> GetContainerAsync()
        {
            if (_container != null) return _container;

            if (StorageAccount != null)
            {
                CloudBlobClient client = StorageAccount.CreateCloudBlobClient();
                _container = client.GetContainerReference(_options.Value.ContainerName);


                if (!await _container.ExistsAsync())
                    await _container.CreateAsync();
            }

            return _container;
        }

        public async Task<Result<string>> UploadFromFileAsync(
            string filePath, string contentType)
        {
            CloudBlobContainer container = await GetContainerAsync();
            if (container == null) return new Result<string>() { Success = false };

            string guid = Guid.NewGuid().ToString();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(guid);
            blockBlob.Properties.ContentType = contentType;

            using (var fileStream = System.IO.File.OpenRead(filePath))
                await blockBlob.UploadFromStreamAsync(fileStream);

            _logger.LogDebug($"UploadFromFileAsync: uploaded new blob (Id = \"{guid}\")");

            return new Result<string>()
            {
                Success = true,
                Data = guid
            };
        }

        public async Task<Result<string>> GetReadUrlAsync(string blobId, int hours = 0)
        {
            CloudBlobContainer container = await GetContainerAsync();
            if (container == null) return new Result<string>() { Success = false };

            CloudBlockBlob blob = container.GetBlockBlobReference(blobId);

            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read;

            sasConstraints.SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5);

            if (hours > 0)
                sasConstraints.SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(hours);
            else
                sasConstraints.SharedAccessExpiryTime = DateTime.MaxValue.ToUniversalTime();

            string sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);

            string url = blob.Uri + sasBlobToken;

            _logger.LogDebug($"GetReadUrlAsync: generated new read URL for blob (Id = \"{blobId}\", URL = \"{url}\")");

            return new Result<string>()
            {
                Success = true,
                Data = url
            };
        }

        public async Task<Result> DeleteBlobs(List<string> blobsIds)
        {
            CloudBlobContainer container = await GetContainerAsync();
            if (container == null) return new Result() { Success = false };

            blobsIds.ForEach(async blobId =>
            {
                await container.GetBlockBlobReference(blobId).DeleteIfExistsAsync();
            });

            return new Result() { Success = true };
        }
    }
}
