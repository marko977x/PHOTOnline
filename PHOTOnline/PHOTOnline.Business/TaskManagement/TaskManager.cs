using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Entities.Enums;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.TaskManagement.Input;
using PHOTOnline.Services.Repositories.Requests;
using PHOTOnline.Services.Repositories.Tasks;

namespace PHOTOnline.Business.TaskManagement
{
    public class TaskManager : ITaskManager
    {
        private ITaskRepository _taskRepository;
        private IRequestRepository _requestRepository;

        public TaskManager(
            ITaskRepository taskRepository,
            IRequestRepository requestRepository)
        {
            _taskRepository = taskRepository;
            _requestRepository = requestRepository;
        }

        public async System.Threading.Tasks.Task<Result<string>> AddTask(AddTaskInput input)
        {
            Task task = new Task()
            {
                Date = input.Date,
                Time = input.Time,
                EventType = input.EventType,
                Location = input.Location,
                Note = input.Note,
                PhotographId = input.PhotographId
            };

            return new Result<string>()
            {
                Success = true,
                Data = await _taskRepository.CreateAsync(task)
            };
        }

        public async System.Threading.Tasks.Task<Result> AssignTask(AssignTaskInput input)
        {
            Task task = new Task()
            {
                Date = input.Date,
                Time = input.Time,
                EventType = input.EventType,
                Location = input.Location,
                Note = input.Note,
                PhotographId = input.PhotographId
            };

            await _taskRepository.CreateAsync(task);
            await _requestRepository.UpdateRequestStatus(
                input.RequestId, RequestStatus.Approved);
            await _requestRepository.UpdateRequestNotification(
                input.RequestId, input.Notification);

            return new Result() { Success = true };
        }
    }
}
