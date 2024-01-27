using Medical.Persistence;
using Medical.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Medical.Api.ContextFactory
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>

    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseSqlServer(configuration.GetConnectionString("MedicalAppointmentDB")!);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
