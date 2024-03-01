using AutoMapper;
using Medical.Application.Dtos.User;
using Medical.Application.UseCase.Features.Auth.Commands.CreateCommand;
using Medical.Domain.Entities;

namespace Medical.Application.UseCase.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForCreationDto, User>().ReverseMap();

            CreateMap<User, UserDto>();

            CreateMap<CreateDoctorCommand, User>();

            CreateMap<CreatePatientCommand, User>();
        }
    }
}
