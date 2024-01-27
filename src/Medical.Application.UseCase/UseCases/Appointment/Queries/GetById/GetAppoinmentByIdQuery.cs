using MediatR;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.UseCases.Appointment.Queries.GetById
{
    public class GetAppoinmentByIdQuery : IRequest<BaseResponse<AppoinmentDto>>
    {
        public string? Id { get; set; }
        public int AppoinmentId { get; set; }
    }
}
