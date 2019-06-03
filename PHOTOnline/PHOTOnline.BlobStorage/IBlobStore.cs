using Microsoft.WindowsAzure.Storage;
using PhotoLine.Domain.Interop;
using PHOTOnline.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.BlobStorage
{
    public interface IBlobStore
    {
        Task<Result<string>> UploadFromFileAsync(string filePath, string contentType);
        Task<Result<string>> GetReadUrlAsync(string blobId, int hours = 0);
        Task<Result> DeleteBlob(Image image);
    }
}
