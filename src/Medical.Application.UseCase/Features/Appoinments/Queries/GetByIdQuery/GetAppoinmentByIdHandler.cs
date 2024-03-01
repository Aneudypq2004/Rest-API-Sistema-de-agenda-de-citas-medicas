using AutoMapper;
using MediatR;
using Medical.Application.Contracts.Persistence;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;
using Medical.Domain.Exceptions.Appoinment;

namespace Medical.Application.UseCase.Features.Appoinments.Queries.GetByIdQuery
{
    public class GetAppoinmentByIdHandler : IRequestHandler<GetAppointmentByIdQuery, BaseResponse<AppoinmentDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAppoinmentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<AppoinmentDto>> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<AppoinmentDto> response = new();

            var appoinment = await unitOfWork.AppointmentRepository.FindById(request.Id) ?? throw new AppoinmentNotFoundException();

            response.Data = mapper.Map<AppoinmentDto>(appoinment);

            return response;
        }
    }
}
