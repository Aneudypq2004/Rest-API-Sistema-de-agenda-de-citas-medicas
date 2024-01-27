using AutoMapper;
using MediatR;
using Medical.Application.Contracts.Persistence;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;

namespace Medical.Application.UseCase.UseCases.Appointment.Queries.GetById
{
    public class GetAppoinmentByIdHandler : IRequestHandler<GetAppoinmentByIdQuery, BaseResponse<AppoinmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAppoinmentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AppoinmentDto>> Handle(GetAppoinmentByIdQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<AppoinmentDto> response = new();

            var appointment = await _unitOfWork.AppointmentRepository.GetAppointmentById(request.Id!, request.AppoinmentId);

            var result = _mapper.Map<AppoinmentDto>(appointment);

            if (result == null)
            {
                response.IsSuccess = false;
                response.Message = "The Id is not valid";
            }

            response.Data = result;

            return response;
        }
    }
}
