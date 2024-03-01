using AutoMapper;
using MediatR;
using Medical.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Medical.Application.UseCase.Features.Auth.Commands.CreateCommand
{
    public class CreateDoctorCommand : IRequest<IdentityResult>
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; set; }
        public string? UserName { get; init; }
        public string? Password { get; init; }

        public string? Specialty { get; set; }
        public string? LicenseNumber { get; set; }
        public string? PhoneNumber { get; init; }
        public ICollection<string>? Roles { get; init; }
    }

    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, IdentityResult>
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public CreateDoctorCommandHandler(UserManager<User> userManager, IMapper mapper )
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = mapper.Map<User>(request);

            var result = await userManager.CreateAsync(doctor, request.Password);

           
            return result;

        }
    }
}
