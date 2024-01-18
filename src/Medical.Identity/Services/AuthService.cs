using AutoMapper;
using Medical.Application.Contracts;
using Medical.Application.Contracts.Infrastructure;
using Medical.Application.Dtos.User;
using Medical.Domain.Entities;
using Medical.Domain.Exceptions;
using Medical.Domain.JwtConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medical.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtConfiguration JwtConfiguration;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthService(UserManager<User> userManager, IMapper mapper, IOptions<JwtConfiguration> jwtConfiguration, IEmailService emailService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            this.JwtConfiguration = jwtConfiguration.Value;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
        }

      
        public async Task<IdentityResult> Register(UserForCreationDto newUser)
        {
            var existUser = await _userManager.FindByEmailAsync(newUser.Email);

            if (existUser is not null)
            {
                throw new BadRequestException("The user already exits");
            }

            var user = _mapper.Map<User>(newUser);

            var result = await _userManager.CreateAsync(user, newUser.Password);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var request = _httpContextAccessor.HttpContext.Request;

                var baseUri = $"{request.Scheme}://{request.Host}";

                var confirmationLink = $"{baseUri}/api/account/auth/confirm?userId={user.UserName}&token={token}";

                await _emailService.SendEmailAsync(new Email
                {
                    To = newUser.Email,
                    Subject = "Confirm Your account",
                    Message = $"Please confirm your account following this link {confirmationLink}"
                });
            }
            return result;
        }



        public async Task<AuthenticateResponse> Login(UserForLoginDto userCredentials)
        {
            AuthenticateResponse authenticateResponse = new();

            var user = await _userManager.FindByEmailAsync(userCredentials.Email) ??
                throw new UserNotFoundException(userCredentials.Email!);

            var result = await _userManager.CheckPasswordAsync(user, userCredentials.Password);

            if (!result)
            {
                throw new Unathorized("The password is invalid or the user is not confirmed");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var rolesClaim = GetClaims(userRoles, user.UserName);

            authenticateResponse.Token = GenerateJwt(rolesClaim);

            return authenticateResponse;
        }

        private string GenerateJwt(List<Claim> UserClaims)
        {
            var secretKey = Environment.GetEnvironmentVariable("JWTKEY");

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(UserClaims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Audience = JwtConfiguration.ValidAudience,
                Issuer = JwtConfiguration.ValidIssuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)), SecurityAlgorithms.HmacSha256)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        private List<Claim> GetClaims(IList<string> roles, String userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;

        }

        public async Task<IdentityResult> ConfirmEmail(string email, string token)
        {

            var user = await _userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);

            var result = await _userManager.ConfirmEmailAsync(user, token);

            return result;
        }
    }

}
