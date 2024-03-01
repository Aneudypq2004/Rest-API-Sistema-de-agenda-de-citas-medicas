using AutoMapper;
using MediatR;
using Medical.Application.Contracts.Persistence;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;
using Medical.Domain.Exceptions.Appoinment;
using Microsoft.EntityFrameworkCore;

namespace Medical.Application.UseCase.Features.Appoinments.Queries.GetAllQuery
{

    public class GetAllAppoinmentHandler : IRequestHandler<GetAllAppoinmentQuery, BaseResponse<IEnumerable<AppoinmentDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllAppoinmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<AppoinmentDto>>> Handle(GetAllAppoinmentQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<IEnumerable<AppoinmentDto>> response = new();

            var appoinment = await unitOfWork.AppointmentRepository.GetAppoinments(request.Id!);

            response.Data = mapper.Map<IEnumerable<AppoinmentDto>>(appoinment);

            return response;
        }
    }
}

