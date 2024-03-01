using MediatR;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.Features.Appoinments.Commands.DeleteCommand
{
    public class DeleteAppoinmentCommand : IRequest<BaseResponse<int>>
    {
        public int AppointmentId { get; set; }
    }
}
