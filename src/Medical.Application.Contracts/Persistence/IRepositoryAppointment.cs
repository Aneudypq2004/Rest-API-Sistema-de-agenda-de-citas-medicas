using Medical.Domain.Entities;

namespace Medical.Application.Contracts.Persistence
{
    public interface IRepositoryAppointment
    {
        Task<IEnumerable<Appointment>> GetAllAppointment(string DoctorId);

        Task<Appointment> GetAppointmentById(string DoctorId, int Id);

        void CreateAppointment(Appointment entity);

        void UpdateAppointment(Appointment entity);

        void DeleteAppointment(Appointment entity);
    }
}
