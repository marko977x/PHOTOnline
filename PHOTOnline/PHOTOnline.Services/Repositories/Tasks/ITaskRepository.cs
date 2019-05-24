using Domain.Entities;
using PhotoLine.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Services.Repositories.Tasks
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        System.Threading.Tasks.Task<List<Task>> GetAllTasksByUserId(string id);
    }
}
