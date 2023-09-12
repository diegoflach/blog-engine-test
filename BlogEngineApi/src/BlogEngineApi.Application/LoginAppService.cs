using BlogEngineApi.Application.Interfaces;
using BlogEngineApi.Common.Utilities;
using BlogEngineApi.Domain.Dtos.Result;
using BlogEngineApi.Domain.Dtos;
using BlogEngineApi.Domain.Statics;
using BlogEngineApi.Infra.Cc.Identity.Managers;
using BlogEngineApi.Infra.Cc.Identity.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogEngineApi.Application
{
    public class LoginAppService : ILoginAppService
    {
        private readonly ApplicationUserManager userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public LoginAppService(ApplicationUserManager userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<LoginResultDto> Login(LoginDto loginDto)
        {
            if (!RegexUtils.IsValidEmail(loginDto.Email))
            {
                throw new ArgumentException(Message.InvalidEmailAddress);
            }

            var user = await userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                throw new UnauthorizedAccessException(Message.InvalidLoginAttempt);
            }

            if (!await userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                await userManager.AccessFailedAsync(user);
                throw new UnauthorizedAccessException(Message.InvalidLoginAttempt);
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, loginDto.Password, true, false);

            if (signInResult.IsLockedOut)
            {
                var lockoutMinutes = DateTime.Now.ToUniversalTime().Subtract(user.LockoutEnd.Value.UtcDateTime).Minutes;

                throw new UnauthorizedAccessException(Message.AccountLockedOut.Replace("@Minutes", lockoutMinutes.ToString()));
            }

            if (signInResult.RequiresTwoFactor)
            {
                throw new UnauthorizedAccessException(Message.TwoFactorIsRequired);
            }

            if (!signInResult.Succeeded)
            {
                throw new UnauthorizedAccessException(Message.InvalidLoginAttempt);
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                claims: claims,
                signingCredentials: credential,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Authentication:ExpirationMinutes"])),
                issuer: configuration["Authentication:Issuer"],
                audience: configuration["Authentication:Audience"]
            );

            return new LoginResultDto(new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);
        }
    }
}