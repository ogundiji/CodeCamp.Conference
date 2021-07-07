using CodeCamp.Conference.Application.Models.Authentication;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
