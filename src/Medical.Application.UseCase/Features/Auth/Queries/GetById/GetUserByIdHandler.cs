using AutoMapper;
using MediatR;
using Medical.Application.Dtos.User;
using Medical.Application.UseCase.Commons.Bases;
using Medical.Application.UseCase.Commons.Exceptions;
using Medical.Application.UseCase.Features.Auth.Queries.GetByEmail;
using Medical.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Medical.Application.UseCase.Features.Auth.Queries.GetById
{
    internal class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, BaseResponse<UserDto>>
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public GetUserByIdHandler(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<UserDto> response = new();

            var result = await userManager.FindByIdAsync(request.Id) ?? throw new NotFoundException("The user doesnt exists");

            response.Data = mapper.Map<UserDto>(result);

            return response;
        }
    }
}
