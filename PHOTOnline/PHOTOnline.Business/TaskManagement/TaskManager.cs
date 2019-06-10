using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Entities.Enums;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.TaskManagement.Input;
using PHOTOnline.Services.Repositories.Requests;
using PHOTOnline.Services.Repositories.Tasks;
using System.Linq;
using PhotoLine.Domain.Errors;
using PHOTOnline.Services.Repositories.Users;

namespace PHOTOnline.Business.TaskManagement
{
    public class TaskManager : ITaskManager
    {
        private ITaskRepository _taskRepository;
        private IRequestRepository _requestRepository;
        private IUserRepository _userRepository;

        public TaskManager(
            ITaskRepository taskRepository,
            IRequestRepository requestRepository,
            IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _requestRepository = requestRepository;
            _userRepository = userRepository;
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
            List<Task> tasks = await _taskRepository.GetAllTasksByUserId(input.PhotographId);
            if (tasks.Find(item => item.Date == input.Date) != null)
            {
                return new Result()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.PhotographIsNotAvailable) }
                };
            }

            PHOTOnlineUser user = await _userRepository.FindAsync(input.CustomerId);

            Task task = new Task()
            {
                Date = input.Date,
                Time = input.Time,
                EventType = input.EventType,
                Location = input.Location,
                Note = input.Note,
                PhotographId = input.PhotographId,
                CustomerFirstName = user.FirstName,
                CustomerLastName = user.LastName,
                CustomerPhoneNumber = user.PhoneNumber
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
