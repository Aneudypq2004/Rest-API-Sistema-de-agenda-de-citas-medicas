using MediatR;
using Medical.Application.Dtos.User;
using Medical.Application.UseCase.Commons.Bases;
using Medical.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Medical.Application.UseCase.Features.Auth.Queries.GetByEmail
{
    public class GetUserByEmailQuery : IRequest<BaseResponse<UserDto>>
    {
        public string? Email { get; set; }
    }
}
