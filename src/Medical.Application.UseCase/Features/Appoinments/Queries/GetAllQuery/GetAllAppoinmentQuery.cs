using MediatR;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.Features.Appoinments.Queries.GetAllQuery
{
    public class GetAllAppoinmentQuery : IRequest<BaseResponse<IEnumerable<AppoinmentDto>>>
    {
        public string? Id { get; set; }
    }
}
