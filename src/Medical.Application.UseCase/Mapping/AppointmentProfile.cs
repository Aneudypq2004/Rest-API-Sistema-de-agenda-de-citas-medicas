using AutoMapper;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.UseCases.Appointment.Commands.CreateCommand;
using Medical.Domain.Entities;

namespace Medical.Application.UseCase.Mapping
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<AppoinmentDto, Appointment>();

            CreateMap<CreateAppoinmentCommand, Appointment>().ForMember(m => m.DoctorId, opt => opt.MapFrom(src => src.DoctorId));

            CreateMap<AppoinmentCreationDto, Appointment>();

            CreateMap<Appointment, AppoinmentDto>().ForMember(dest => dest.State, opt =>
            opt.MapFrom(src => src.State ? "Active" : "Completed"));

        }
    }
}
