using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Enums;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.RequestManagement.Input;
using PHOTOnline.Services.Repositories.Requests;
using System.Linq;
using Task = System.Threading.Tasks.Task;

namespace PHOTOnline.Business.RequestManagement
{
    public class RequestManager : IRequestManager
    {
        private IRequestRepository _requestRepository;
        private const int MAXIMUM_REQUEST_DAYS = 30;

        public RequestManager(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Result<string>> CreateRequest(CreateRequestInput input)
        {
            Request request = new Request()
            {
                AdditionalRequests = input.AdditionalRequests,
                Date = input.Date,
                EventType = input.EventType,
                Location = input.Location,
                UserId = input.UserId,
                Time = input.Time,
                FirstName = input.FirstName,
                LastName = input.LastName,
                RequestStatus = RequestStatus.OnHold
            };

            return new Result<string>()
            {
                Success = true,
                Data = await _requestRepository.CreateAsync(request)
            };
        }

        public async Task<Result<List<Request>>> GetAllRequests()
        {
            List<Request> requests = await _requestRepository.GetAllRequests();
            List<Task> tasks = new List<Task>();
            requests.RemoveAll(request =>
            {
                DateTime result;
                bool success = DateTime.TryParse(request.Date, out result);
                if (success)
                {
                    result.AddDays(MAXIMUM_REQUEST_DAYS);
                    if (DateTime.Now.Date.CompareTo(result) == 1) { return true; }
                    else return false;
                }
                else
                {
                    return false;
                }
            });

            await Task.WhenAll(tasks);

            return new Result<List<Request>>()
            {
                Success = true,
                Data = requests
            };
        }

        public async Task<Result> RejectRequest(RejectRequestInput input)
        {
            await _requestRepository.UpdateRequestStatus(
                input.Id, RequestStatus.Rejected);

            await _requestRepository.UpdateRequestNotification(
                input.Id, input.Notification);

            return new Result() { Success = true };
        }
    }
}
