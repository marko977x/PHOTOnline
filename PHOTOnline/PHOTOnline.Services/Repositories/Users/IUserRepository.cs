using Domain.Entities;
using PhotoLine.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Repositories.Users
{
    public interface IUserRepository : IGenericRepository<PHOTOnlineUser>
    {
        Task<List<PHOTOnlineUser>> GetAllPhotographs();
        Task<List<PHOTOnlineUser>> GetAllUsers();
    }
}
