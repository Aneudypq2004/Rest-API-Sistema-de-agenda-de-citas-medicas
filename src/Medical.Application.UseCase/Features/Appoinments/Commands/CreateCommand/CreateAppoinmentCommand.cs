using MediatR;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.Features.Appoinments.Commands.CreateCommand
{
    public class CreateAppoinmentCommand : IRequest<BaseResponse<AppoinmentDto>>
    {
        public AppoinmentCreationDto? NewAppoinment { get; set; }

        public string? DoctorId { get; set; }
        public string? PatientId { get; set; }
    }
}
