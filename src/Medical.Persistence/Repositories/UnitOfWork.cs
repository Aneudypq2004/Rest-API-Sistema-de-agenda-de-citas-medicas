using Medical.Application.Contracts;
using Medical.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IRepositoryAppointment> repositoryAppointment;

        public IRepositoryAppointment AppointmentRepository => repositoryAppointment.Value;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            repositoryAppointment = new Lazy<IRepositoryAppointment>(() => new RepositoryAppointment(context));
        }

        public async Task SaveChanges() =>  await _context.SaveChangesAsync();
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
