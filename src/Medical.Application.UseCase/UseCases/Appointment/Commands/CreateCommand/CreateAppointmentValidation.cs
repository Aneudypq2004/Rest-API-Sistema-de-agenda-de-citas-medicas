using FluentValidation;

namespace Medical.Application.UseCase.UseCases.Appointment.Commands.CreateCommand
{
    public class CreateAppointmentValidation : AbstractValidator<CreateAppoinmentCommand>
    {
        public CreateAppointmentValidation()
        {
            RuleFor(x => x.AppoinmentCreation!.Description).NotEmpty().Length(20, 100);
            
           
        }
    }
}
