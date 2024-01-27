using MediatR;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.UseCases.Appointment.Commands.DeleteCommand
{
    public class DeleteAppoinmentCommand : IRequest<BaseResponse<int>>
    {
        public string? DoctorId { get; set; }
        public int AppoinmentId { get; set; }
    }
}
