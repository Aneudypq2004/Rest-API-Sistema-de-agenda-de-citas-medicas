using AutoMapper;
using MediatR;
using Medical.Application.Contracts.Persistence;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.UseCases.Appointment.Queries.GetAllQuery
{
    public class GetAllAppoinmentHandler : IRequestHandler<GetAllAppoinmentsQuery, BaseResponse<IEnumerable<AppoinmentDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAppoinmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<AppoinmentDto>>> Handle(GetAllAppoinmentsQuery request, CancellationToken cancellationToken)
        {

            BaseResponse<IEnumerable<AppoinmentDto>> response = new();

            var appointments = await _unitOfWork.AppointmentRepository.GetAllAppointment(request.DoctorId!);

            var result = _mapper.Map<IEnumerable<AppoinmentDto>>(appointments);

            if (!result.Any())
            {
                response.IsSuccess = false;
                response.Message = "The Id is not valid";
            }

            response.Data = result;

            return response;
        }
    }
}
