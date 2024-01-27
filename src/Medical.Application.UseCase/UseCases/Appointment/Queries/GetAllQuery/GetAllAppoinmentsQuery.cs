using MediatR;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.UseCases.Appointment.Queries.GetAllQuery
{
    public class GetAllAppoinmentsQuery : IRequest<BaseResponse<IEnumerable<AppoinmentDto>>>
    {
        public string? DoctorId { get; set; }
    }
}
