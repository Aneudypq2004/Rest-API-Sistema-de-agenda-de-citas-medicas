using Medical.Domain.Entities;

namespace Medical.Application.Contracts.Persistence
{
    public interface IAppointmentRepository: IBaseRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppoinments(string id);
    }
}
