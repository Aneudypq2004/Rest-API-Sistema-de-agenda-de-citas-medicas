using AutoMapper;
using MediatR;
using Medical.Application.Contracts.Persistence;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Commons.Bases;
using Medical.Domain.Exceptions.Appoinment;

namespace Medical.Application.UseCase.Features.Appoinments.Commands.DeleteCommand
{
    public class DeleteAppoinmentHandler : IRequestHandler<DeleteAppoinmentCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteAppoinmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(DeleteAppoinmentCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<int> response = new();

            var appoinment = await unitOfWork.AppointmentRepository.FindById(request.AppointmentId) ?? throw new AppoinmentNotFoundException();

            unitOfWork.AppointmentRepository.Remove(appoinment);

            await unitOfWork.SaveChanges();

            response.Message = "Appoinment Deleted";
            
            return response;
        }
    }
}
