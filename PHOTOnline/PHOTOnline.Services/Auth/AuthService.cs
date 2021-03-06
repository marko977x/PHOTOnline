﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.MongoDB;
using PhotoLine.Domain.Errors;
using PhotoLine.Domain.Interop;
using PHOTOnline.Services.Auth.Output;
using System.Linq;

namespace PHOTOnline.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<PHOTOnlineUser> _userManager;
        private readonly SignInManager<PHOTOnlineUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(
            UserManager<PHOTOnlineUser> userManager,
            SignInManager<PHOTOnlineUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<Result<string>> CreateUserAsync(PHOTOnlineUser user, string password)
        {
            var operationResult = default(IdentityResult);
            operationResult = await _userManager.CreateAsync(user, password);

            if (IsDuplicateEmail(operationResult))
            {
                return new Result<string>()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.DuplicateEmail) }
                };
            }

            if (IsDuplicateUserName(operationResult))
            {
                return new Result<string>()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.DuplicateUserName) }
                };
            }

            if (IsDuplicateEmail(operationResult))
            {
                return new Result<string>()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.DuplicateEmail) }
                };
            }

            if (IsPasswordToShort(operationResult))
            {
                return new Result<string>()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.PasswordTooShort) }
                };
            }

            if (IsInvalidEmail(operationResult))
            {
                return new Result<string>()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.InvalidEmail) }
                };
            }

            return new Result<string>() { Success = true, Data = user.Id };
        }

        public async Task<Result> UpdateCredentials(
            string currentEmail, string newEmail, string newPassword,
            string newAddress, string newPhoneNumber)
        {
            PHOTOnlineUser user = await _userManager.FindByEmailAsync(currentEmail);

            if (user == null) return new Result() { Success = false };

            user.Email = newEmail;
            user.Address = newAddress;
            user.PhoneNumber = newPhoneNumber;

            IdentityResult userResult = await _userManager.UpdateAsync(user);
            if (!userResult.Succeeded) return new Result() { Success = false };

            string passwordToken = await _userManager
                .GeneratePasswordResetTokenAsync(user);

            IdentityResult passwordResult = await _userManager.ResetPasswordAsync(
                user, passwordToken, newPassword);

            return new Result() { Success = passwordResult.Succeeded };
        }

        public async Task<Result> UpdatePassword(
            string userId, string oldPassword, string newPassword)
        {
            PHOTOnlineUser user = await _userManager.FindByIdAsync(userId);

            if (user == null) return new Result() { Success = false };

            bool checkPassword = await _userManager
                .CheckPasswordAsync(user, oldPassword);

            if (!checkPassword) return new Result()
            {
                Success = false,
                Errors = new List<Error>() { new Error(ErrorCode.WrongOldPassword) }
            };

            string passwordToken = await _userManager
                .GeneratePasswordResetTokenAsync(user);

            IdentityResult passwordResult = await _userManager.ResetPasswordAsync(
                user, passwordToken, newPassword);

            if (IsPasswordToShort(passwordResult))
            {
                return new Result()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.PasswordTooShort) }
                };
            }

            return new Result() { Success = passwordResult.Succeeded };
        }

        public async Task<Result> AddUserToRoleAsync(PHOTOnlineUser user, string roleName)
        {
            IdentityRole role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) await _roleManager.CreateAsync(new IdentityRole(roleName));

            IdentityResult result = await _userManager.AddToRoleAsync(user, roleName);
            return new Result() { Success = result.Succeeded };
        }

        public async Task<Result> AddUserToRoleByEmail(string email, string roleName)
        {
            PHOTOnlineUser user = await _userManager.FindByEmailAsync(email);
            if (user == null) return new Result() { Success = false };

            return await AddUserToRoleAsync(user, roleName);
        }

        public async Task<Result> DeleteUser(string id)
        {
            PHOTOnlineUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return new Result() { Success = false };

            IdentityResult result = await _userManager.DeleteAsync(user);
            return new Result() { Success = result.Succeeded };
        }

        public async Task<Result<PHOTOnlineUser>> GetUserById(string id)
        {
            PHOTOnlineUser user = await _userManager.FindByIdAsync(id);

            return new Result<PHOTOnlineUser>()
            {
                Success = user == null ? false : true,
                Data = user
            };
        }

        public async Task<Result<SignInOutput>> SignInAsync(string email, string password)
        {
            PHOTOnlineUser user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new Result<SignInOutput>()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.WrongEmail) }
                };
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(
                user, password, false, false);

            if (signInResult.Succeeded)
            {
                return new Result<SignInOutput>()
                {
                    Success = true,
                    Data = new SignInOutput() { Id = user.Id, UserType = user.UserType }
                };
            }
            else
            {
                return new Result<SignInOutput>()
                {
                    Success = false,
                    Errors = new List<Error>() { new Error(ErrorCode.WrongPassword) }
                };
            }

        }

        public async Task<Result> SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            return new Result() { Success = true };
        }

        public async Task<Result<PHOTOnlineUser>> GetUserByEmail(string email)
        {
            PHOTOnlineUser user = await _userManager.FindByEmailAsync(email);

            return new Result<PHOTOnlineUser>()
            {
                Success = user == null ? false : true,
                Data = user
            };
        }

        private bool IsDuplicateEmail(IdentityResult result)
        {
            return result.Errors.Any(error => error.Code == "DuplicateEmail");
        }

        private bool IsDuplicateUserName(IdentityResult result)
        {
            return result.Errors.Any(error => error.Code == "DuplicateUserName");
        }

        private bool IsInvalidEmail(IdentityResult result)
        {
            return result.Errors.Any(error => error.Code == "InvalidEmail");
        }

        private bool IsPasswordToShort(IdentityResult result)
        {
            return result.Errors.Any(error => error.Code == "PasswordTooShort");
        }
    }
}
