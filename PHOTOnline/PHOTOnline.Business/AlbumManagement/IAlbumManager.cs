﻿using PhotoLine.Domain.Interop;
using PHOTOnline.Business.AlbumManagement.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Business.AlbumManagement
{
    public interface IAlbumManager
    {
        Task<Result> DeleteAlbum(string id);
        Task<Result<string>> AddAlbum(AddAlbumInput input);
        Task<Result> DeleteImage(DeleteImageInput input);
    }
}
