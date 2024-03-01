using AutoMapper;
using Medical.Application.Contracts.Persistence;

namespace Medical.Application.UseCase.Features.Appoinments.Commands.UpdateCommand
{
    public class UpdateCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
    }
}
