using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.Services.Auth.Output;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Auth
{
    public interface IAuthService
    {
        Task<Result<string>> CreateUserAsync(PHOTOnlineUser user, string password);
        Task<Result> UpdateCredentials(string currentEmail, string newEmail,
            string newPassword, string newAddress, string newPhoneNumber);
        Task<Result> DeleteUser(string id);
        Task<Result<PHOTOnlineUser>> GetUserById(string id);
        Task<Result<PHOTOnlineUser>> GetUserByEmail(string email);
        Task<Result> AddUserToRoleByEmail(string email, string roleName);
        Task<Result<SignInOutput>> SignInAsync(string email, string password);
        Task<Result> SignOutAsync();
        Task<Result> UpdatePassword(string userId, string oldPassword, string newPassword);
    }
}
