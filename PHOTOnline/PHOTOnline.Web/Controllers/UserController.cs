using System.Threading.Tasks;
using Business.UserManagement;
using Business.UserManagement.Input;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.UserManagement.Input;
using PHOTOnline.Services.Auth;

namespace PHOTOnline.Web.Controllers
{
    [Route("/api/[controller]/[action]")]
    [Produces("application/json")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserAccount _userAccount;
        private readonly IAuthService _authService;

        public UserController(IUserAccount userAccount, IAuthService authService)
        {
            _authService = authService;
            _userAccount = userAccount;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserInput input)
        {
            Result<string> result = await _userAccount.CreateUserAsync(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCredentials(
            [FromBody]UpdateCredentialsInput input)
        {
            Result result = await _userAccount.UpdateCredentials(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            Result result = await _authService.DeleteUser(id);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(string id)
        {
            Result<PHOTOnlineUser> result = await _authService.GetUserById(id);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            Result<PHOTOnlineUser> result = await _authService.GetUserByEmail(email);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInInput input)
        {
            Result result = await _authService.SignInAsync(
                input.Email, input.Password);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            Result result = await _authService.SignOutAsync();
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

    }

}