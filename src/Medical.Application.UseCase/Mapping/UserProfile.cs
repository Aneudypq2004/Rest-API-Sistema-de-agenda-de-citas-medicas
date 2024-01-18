using AutoMapper;
using Medical.Application.Dtos.User;
using Medical.Domain.Entities;

namespace Medical.Application.UseCase.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForCreationDto, User>().ReverseMap();
        }
    }
}
