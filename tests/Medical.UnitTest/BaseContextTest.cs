using Medical.Domain.Entities;
using Medical.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Medical.UnitTest
{
    public class BaseContextTest : IDisposable
    {
        protected readonly MedicalDbContext _context;

        public BaseContextTest()
        {
            var options = new DbContextOptionsBuilder<MedicalDbContext>()
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
                
            this._context = new MedicalDbContext(options);
            this._context.Database.EnsureCreated();
            Seed();

        }

        public void Dispose()
        {
            this._context.Database.EnsureDeleted();
            this._context.Dispose();
        }

        private async void Seed()
        {
            List<Appointment> appointments = new();

            for (int i = 1; i <= 5; i++)
            {
                Appointment appointment = new ()
                {
                    Id = i,
                    State = true, 
                    Description = $"Descripción de la cita {i}",
                    DoctorId = $"Doctor{i}"
                };

                appointments.Add(appointment);
            }

            foreach (var item in appointments)
            {
                _context.Appointments!.Add(item);
            }

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
        }
    }
}
