﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Business.UserManagement;
using Business.UserManagement.Input;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.UserManagement.Input;
using PHOTOnline.Services.Auth;
using PHOTOnline.Services.Auth.Output;
using PHOTOnline.Services.Repositories.Users;

namespace PHOTOnline.Web.Controllers
{
    [Route("/api/[controller]/[action]")]
    //[Authorize]
    public class UserController : Controller
    {
        private readonly IUserAccount _userAccount;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public UserController(
            IUserAccount userAccount,
            IAuthService authService,
            IUserRepository userRepository)
        {
            _authService = authService;
            _userAccount = userAccount;
            _userRepository = userRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromForm]CreateUserInput input)
        {
            Result<string> result = await _userAccount.CreateUserAsync(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhotographAsync([FromForm]CreatePhotographInput input)
        {
            Result<string> result = await _userAccount.CreatePhotographAsync(input);
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
        public async Task<IActionResult> ResetPassword([FromForm]UpdatePasswordInput input)
        {
            Result result = await _userAccount.UpdatePassword(input);
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
        public async Task<IActionResult> SignIn([FromForm] SignInInput input)
        {
            Result<SignInOutput> result = await _authService.SignInAsync(
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

        [HttpGet]
        public async Task<IActionResult> GetAllPhotographs()
        {
            return Ok(new Result<List<PHOTOnlineUser>>()
            {
                Success = true,
                Data = await _userRepository.GetAllPhotographs()
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegularUsers()
        {
            return Ok(new Result<List<PHOTOnlineUser>>()
            {
                Success = true,
                Data = await _userRepository.GetAllRegularUsers()
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(new Result<List<PHOTOnlineUser>>()
            {
                Success = true,
                Data = await _userRepository.GetAllUsers()
            });
        }

    }

}