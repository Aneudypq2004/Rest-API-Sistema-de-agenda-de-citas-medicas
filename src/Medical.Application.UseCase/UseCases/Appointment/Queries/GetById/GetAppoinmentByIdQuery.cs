using MediatR;
using Medical.Application.Dtos.Appoinment.Response;
using Medical.Application.UseCase.Commons.Bases;


namespace Medical.Application.UseCase.UseCases.Appointment.Queries.GetById
{
    public class GetAppoinmentByIdQuery : IRequest<BaseResponse<GetAppointmentDto>>
    {
        public string Id { get; set; }
    }
}
