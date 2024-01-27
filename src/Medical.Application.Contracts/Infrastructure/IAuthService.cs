using Medical.Application.Dtos.User;
using Medical.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Medical.Application.Contracts.Infrastructure
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(UserForCreationDto newUser);
        Task<AuthenticateResponse> Login(UserForLoginDto userCredentials);

        Task<IdentityResult> ConfirmEmail(string email, string token);
    }
}
