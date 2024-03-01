using Medical.Application.Contracts.Persistence;
using Medical.Domain.Entities;
using Medical.Persistence.Context;
using Medical.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace Medical.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(MedicalDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Appointment>> GetAppoinments(string id)
        {
            return await dbContext.Appointments!.Where(a => a.DoctorId == id).ToListAsync();
        }
    }
}
