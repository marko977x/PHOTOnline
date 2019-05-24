using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.TaskManagement;
using PHOTOnline.Business.TaskManagement.Input;
using PHOTOnline.Services.Repositories.Tasks;

namespace PHOTOnline.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class TaskController : Controller
    {
        private ITaskManager _taskManager;
        private ITaskRepository _taskRepository;

        public TaskController(
            ITaskManager taskManager,
            ITaskRepository taskRepository)
        {
            _taskManager = taskManager;
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task<IActionResult> AddTask(AddTaskInput input)
        {
            Result<string> result = await _taskManager.AddTask(input);

            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        public async System.Threading.Tasks.Task<IActionResult> AssignTask(AssignTaskInput input)
        {
            Result result = await _taskManager.AssignTask(input);

            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        public async System.Threading.Tasks.Task<IActionResult> GetAllTasks()
        {
            return Ok(new Result<List<Task>>()
            {
                Success = true,
                Data = await _taskRepository.GetAll()
            });
        }

        public async System.Threading.Tasks.Task<IActionResult> GetAllTasksByUserId(string id)
        {
            return Ok(new Result<List<Task>>()
            {
                Success = true,
                Data = await _taskRepository.GetAllTasksByUserId(id)
            });
        }
    }
}