using PhotoLine.Domain.Interop;
using PHOTOnline.Business.TaskManagement.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Business.TaskManagement
{
    public interface ITaskManager
    {
        Task<Result<string>> AddTask(AddTaskInput input);
        Task<Result> AssignTask(AssignTaskInput input);
    }
}
