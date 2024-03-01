using MediatR;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.Features.Appoinments.Queries.GetByIdQuery
{
    public class GetAppointmentByIdQuery : IRequest<BaseResponse<AppoinmentDto>>
    {
        public int Id { get; set; }
    }
}
