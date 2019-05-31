using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.RequestManagement.Input;
using PHOTOnline.Services.Repositories.Requests;

namespace PHOTOnline.Business.RequestManagement
{
    public class RequestManager : IRequestManager
    {
        private IRequestRepository _requestRepository;

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
                Time = input.Time
            };

            return new Result<string>()
            {
                Success = true,
                Data = await _requestRepository.CreateAsync(request)
            };
        }
    }
}
