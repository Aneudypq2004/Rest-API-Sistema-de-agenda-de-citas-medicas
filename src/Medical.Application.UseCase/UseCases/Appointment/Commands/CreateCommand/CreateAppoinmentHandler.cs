using AutoMapper;
using MediatR;
using Medical.Application.Contracts.Persistence;
using Medical.Application.UseCase.Commons.Bases;
using Medical.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Medical.Application.UseCase.UseCases.Appointment.Commands.CreateCommand
{
    public class CreateAppoinmentHandler : IRequestHandler<CreateAppoinmentCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateAppoinmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(CreateAppoinmentCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<int> response = new();

            var appoinment = _mapper.Map<Medical.Domain.Entities.Appointment>(request.AppoinmentCreation);

            appoinment.DoctorId = request.DoctorId;           
            
            _unitOfWork.AppointmentRepository.CreateAppointment(appoinment);

            var result = await _unitOfWork.SaveChanges();

            if(result == 0)
            {
                response.IsSuccess = false;
                response.Message = "Something is wrong";
            }
            response.Data = result;

            return response;
        }
    }
}
