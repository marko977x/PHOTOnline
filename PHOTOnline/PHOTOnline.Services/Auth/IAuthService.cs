using Domain.Entities;
using PhotoLine.Domain.Interop;
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
        Task<Result> SignInAsync(string email, string password);
        Task<Result> SignOutAsync();
    }
}
