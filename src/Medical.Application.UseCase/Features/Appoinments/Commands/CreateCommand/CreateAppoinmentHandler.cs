using AutoMapper;
using MediatR;
using Medical.Application.Contracts.Persistence;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;
using Medical.Domain.Entities;

namespace Medical.Application.UseCase.Features.Appoinments.Commands.CreateCommand
{
    public class CreateAppoinmentHandler : IRequestHandler<CreateAppoinmentCommand, BaseResponse<AppoinmentDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateAppoinmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<AppoinmentDto>> Handle(CreateAppoinmentCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<AppoinmentDto> response = new();

            var appoinment = mapper.Map<Appointment>(request.NewAppoinment);
            appoinment.DoctorId = request.DoctorId;
            appoinment.PatientId = request.PatientId;

            unitOfWork.AppointmentRepository.Create(appoinment);
            await unitOfWork.SaveChanges();

            response.Data = mapper.Map<AppoinmentDto>(appoinment);
            response.Message = "Created Successfully";


            return response;
        }
    }
}
