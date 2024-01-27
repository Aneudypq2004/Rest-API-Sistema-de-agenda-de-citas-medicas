using AutoMapper;
using MediatR;
using Medical.Application.Contracts.Persistence;
using Medical.Application.UseCase.Commons.Bases;
using Medical.Domain.Entities;
using Medical.Domain.Exceptions;

namespace Medical.Application.UseCase.UseCases.Appointment.Commands.DeleteCommand
{
    public class DeleteAppoinmentCommandHandler : IRequestHandler<DeleteAppoinmentCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAppoinmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(DeleteAppoinmentCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<int> response = new();

            var appointment = await _unitOfWork.AppointmentRepository.GetAppointmentById(request.DoctorId!, request.AppoinmentId);

            if (appointment is null) throw new NotFoundException("The DoctorId or AppoinmentId is not valid");

             _unitOfWork.AppointmentRepository.DeleteAppointment(appointment);

            await _unitOfWork.SaveChanges();

            response.Message = "Delete Successfully";

            return response;
        }
    }
}
