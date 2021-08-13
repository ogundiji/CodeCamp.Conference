using CodeCamp.Conference.Application.Contracts.Identity;
using CodeCamp.Conference.Application.Models.Authentication;
using CodeCamp.Conference.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Identity.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var response = new AuthenticationResponse();

            if (user == null)
            {
                response.Success = false;
                response.statusCode = 404;
                throw new Exception($"User with {request.Email} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                response.Success = false;
                response.statusCode = 400;
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            if (response.Success)
            {
                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
                response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                response.Message = "Login Successful";
                response.statusCode = 200;
            }

            return response;
        }

        public async Task<EmailConfirmationResponse> GenerateEmailConfirmation(EmailConfirmationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var response = new EmailConfirmationResponse();

            if (user == null)
            {
                response.Success = false;
                response.statusCode = 404;
                throw new Exception("record not found");
            }

            if (response.Success)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                response.token = token;
                response.userId = user.Id.ToString();
                response.Message = "successfully generated token";
            }

            return response;
        }

        // public async Task<> 

        public async Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.email);
            var response = new ForgotPasswordResponse();

            if (user == null)
            {
                response.Success = false;
                response.statusCode = 404;
                throw new Exception("record not found");
            }

            if (response.Success)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                response.token = token;
                response.userId = user.Id.ToString();
                response.Message = "Successfully  generate token";
                response.token = token;
            }

            return response;
        }



        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);
            var response = new RegistrationResponse();


            if (existingUser != null)
            {
                response.Success = false;
                response.statusCode = 400;
                throw new Exception($"Username '{request.Username}' already exists.");
            }

            var user = new User
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                UserName = request.Username,
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    response.UserId = user.Id.ToString();
                    response.statusCode = 200;
                    return response;
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email } already exists.");
            }
        }

        public async Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest request)
        {
            var response = new ResetPasswordResponse();
            var user = await _userManager.FindByEmailAsync(request.email);

            if (user == null)
            {
                response.Success = false;
                response.statusCode = 400;
                response.Message = "Bad Request";
            }

            if (response.Success)
            {
                var result = await _userManager.ResetPasswordAsync(user, request.token, request.email);
                if (result.Succeeded)
                {
                    response.statusCode = 200;
                    response.Message = "password reset successfully";
                }
                else
                {
                    response.statusCode = 400;
                    response.Message = "Bad Request";
                }
            }


            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public async Task<ConfirmedEmailResponse> ConfirmEmail(ConfirmedEmailRequest request)
        {
            var response = new ConfirmedEmailResponse();
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.statusCode = 404;
                response.Success = false;
            }

            if (response.Success)
            {
                var result = await _userManager.ConfirmEmailAsync(user, request.token);
                if (result.Succeeded)
                {
                    response.statusCode = 200;
                    response.userId = user.Id.ToString();
                }
                else
                {
                    response.statusCode = 500;
                    response.Success = false;
                }
            }

            return response;
        }

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request)
        {
            var response = new ChangePasswordResponse();
            var user = await _userManager.FindByIdAsync(request.userId);

            if (user == null)
            {
                response.Success = false;
                response.statusCode = 400;
                response.Message = "Bad Request";
            }

            if (await _userManager.IsEmailConfirmedAsync(user))
            {
                response.Success = false;
                response.statusCode = 400;
                response.Message = "You have not Confirm your Email";
            }

            var result = await _userManager.AddPasswordAsync(user, request.password);
            if (result.Succeeded)
            {
                response.statusCode = 200;
                response.Message = "password successfully added to this account";
            }
            else
            {
                response.statusCode = 500;
                response.Message = "Bad Request";
                response.Success = true;
            }

            return response;
        }
    }
}
