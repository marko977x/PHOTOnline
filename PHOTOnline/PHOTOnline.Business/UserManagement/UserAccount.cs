using System.Threading.Tasks;
using Business.UserManagement.Input;
using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.Services.Auth;

namespace Business.UserManagement
{
    public class UserAccount : IUserAccount
    {
        private readonly IAuthService _authService;

        public UserAccount(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result<string>> CreateUserAsync(CreateUserInput input)
        {
            PHOTOnlineUser user = new PHOTOnlineUser()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Address = input.Address,
                Email = input.Email,
                UserName = input.Username,
                PhoneNumber = input.PhoneNumber
            };

            Result<string> result = await
                _authService.CreateUserAsync(user, input.Password);

            await _authService.AddUserToRoleByEmail(
                input.Email, input.UserType.ToString());

            return result;
        }

        public async Task<Result> UpdateCredentials(UpdateCredentialsInput input)
        {
            return await _authService.UpdateCredentials(
                input.CurrentEmail, input.NewEmail, input.NewPassword,
                input.NewAddress, input.NewPhoneNumber);
        }
    }
}
