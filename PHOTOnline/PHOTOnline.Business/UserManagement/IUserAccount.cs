using Business.UserManagement.Input;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.UserManagement.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.UserManagement
{
    public interface IUserAccount
    {
        Task<Result<string>> CreateUserAsync(CreateUserInput input);
        Task<Result<string>> CreatePhotographAsync(CreatePhotographInput input);
        Task<Result> UpdateCredentials(UpdateCredentialsInput input);
        Task<Result> UpdatePassword(UpdatePasswordInput input);
    }
}
