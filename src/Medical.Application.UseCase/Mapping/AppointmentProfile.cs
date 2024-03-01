using AutoMapper;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Domain.Entities;

namespace Medical.Application.UseCase.Mapping
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<AppoinmentDto, Appointment>();

        }
    }
}
