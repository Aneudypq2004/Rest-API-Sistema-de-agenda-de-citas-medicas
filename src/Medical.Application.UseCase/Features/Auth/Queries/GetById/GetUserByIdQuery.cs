using MediatR;
using Medical.Application.Dtos.User;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.Features.Auth.Queries.GetById
{
    public class GetUserByIdQuery : IRequest<BaseResponse<UserDto>>
    {
        public string? Id { get; set; }
    }
}
