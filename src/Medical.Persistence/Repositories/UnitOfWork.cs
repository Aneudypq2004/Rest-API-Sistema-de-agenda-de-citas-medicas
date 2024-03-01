using Medical.Application.Contracts.Persistence;
using Medical.Persistence.Context;

namespace Medical.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicalDbContext _context;
        private readonly Lazy<IAppointmentRepository> repositoryAppointment;

        public IAppointmentRepository AppointmentRepository => repositoryAppointment.Value;

        public UnitOfWork(MedicalDbContext context)
        {
            _context = context;

            repositoryAppointment = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(context));
        }

        public async Task<int> SaveChanges() =>  await _context.SaveChangesAsync();
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
