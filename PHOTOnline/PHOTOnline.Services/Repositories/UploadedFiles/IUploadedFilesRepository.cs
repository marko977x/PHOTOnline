using PhotoLine.Services.Repositories;
using PHOTOnline.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Services.Repositories.UploadedFiles
{
    public interface IUploadedFilesRepository :
        IGenericRepository<UploadedFile>
    {
    }
}
