using Medical.Application.Contracts.Persistence;
using Medical.Domain.Entities;
using Medical.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Persistence.Repositories
{
    public class RepositoryAppointment : RepositoryBase<Appointment>, IRepositoryAppointment
    {
        public RepositoryAppointment(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void CreateAppointment(Appointment entity) => Create(entity);

        public void DeleteAppointment(Appointment entity) => Remove(entity);

        public async Task<IEnumerable<Appointment>> GetAllAppointment(string DoctorId) => await FindByCondition(a => a.DoctorId! == DoctorId).ToListAsync();

        public async Task<Appointment>? GetAppointmentById(string DoctorId, int Id)
        {
            return await FindByCondition(a => a.DoctorId! == DoctorId && a.Id == Id).FirstOrDefaultAsync();
        }

        public void UpdateAppointment(Appointment entity) => Update(entity);
    }
}
