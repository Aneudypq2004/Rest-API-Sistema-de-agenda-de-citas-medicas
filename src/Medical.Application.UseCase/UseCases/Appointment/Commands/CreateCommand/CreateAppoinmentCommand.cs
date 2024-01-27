using MediatR;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.UseCases.Appointment.Commands.CreateCommand
{
    public class CreateAppoinmentCommand : IRequest<BaseResponse<int>>
    {
        public string? DoctorId { get; set; }

        public AppoinmentCreationDto? AppoinmentCreation { get; set; }

    }
}
