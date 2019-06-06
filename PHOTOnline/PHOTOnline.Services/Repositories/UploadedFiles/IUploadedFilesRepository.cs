using PhotoLine.Services.Repositories;
using PHOTOnline.Domain.Entities.Images;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Repositories.UploadedFiles
{
    public interface IUploadedFilesRepository :
        IGenericRepository<UploadedFile>
    {
        Task<List<UploadedFile>> DeleteUploadedFiles(List<string> ids);
    }
}
