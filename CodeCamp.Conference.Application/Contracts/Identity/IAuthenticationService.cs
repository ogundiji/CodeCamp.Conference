﻿using CodeCamp.Conference.Application.Models.Authentication;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<EmailConfirmationResponse> GenerateEmailConfirmation(EmailConfirmationRequest request);
        Task<ConfirmedEmailResponse> ConfirmEmail(ConfirmedEmailRequest request);
        Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request);

        Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest request);
        Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest request);

    }
}
