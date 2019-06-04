using Domain.Entities;
using Domain.Entities.Enums;
using PhotoLine.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Repositories.Requests
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<List<Request>> GetAllRequests();
        Task<List<Request>> GetRequestsByUserId(string id);
        System.Threading.Tasks.Task DeleteResolvedRequests();
        System.Threading.Tasks.Task UpdateRequestStatus(
            string requestId, RequestStatus requestStatus);
        System.Threading.Tasks.Task UpdateRequestNotification(
            string requestId, string notification);
    }
}
