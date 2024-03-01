using AutoMapper;
using MediatR;
using Medical.Application.Dtos.User;
using Medical.Application.UseCase.Commons.Bases;
using Medical.Domain.Entities;
using Medical.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Medical.Application.UseCase.Features.Auth.Queries.GetByEmail
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, BaseResponse<UserDto>>
    {

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public GetUserByEmailHandler(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<UserDto> response = new();

            var result = await userManager.FindByEmailAsync(request.Email) ?? throw new NotFoundException("The user doesnt exists");

            response.Data = mapper.Map<UserDto>(result);

            return response;
        }
    }
}
