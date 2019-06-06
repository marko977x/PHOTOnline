using PhotoLine.Domain.Interop;
using PHOTOnline.Business.RequestManagement.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Business.RequestManagement
{
    public interface IRequestManager
    {
        Task<Result<string>> CreateRequest(CreateRequestInput input);
        Task<Result> RejectRequest(RejectRequestInput input);
    }
}
