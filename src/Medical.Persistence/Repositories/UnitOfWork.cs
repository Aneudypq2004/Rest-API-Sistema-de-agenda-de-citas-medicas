using Medical.Application.Contracts.Persistence;
using Medical.Persistence.Context;

namespace Medical.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicalDbContext _context;
        private readonly Lazy<IRepositoryAppointment> repositoryAppointment;

        public IRepositoryAppointment AppointmentRepository => repositoryAppointment.Value;

        public UnitOfWork(MedicalDbContext context)
        {
            _context = context;

            repositoryAppointment = new Lazy<IRepositoryAppointment>(() => new RepositoryAppointment(context));
        }

        public async Task<int> SaveChanges() =>  await _context.SaveChangesAsync();
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
