﻿using Medical.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Medical.Api.ContextFactory
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<MedicalDbContext>

    {
        public MedicalDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var builder = new DbContextOptionsBuilder<MedicalDbContext>().
                UseSqlServer(configuration.GetConnectionString("MedicalAppointmentDB")!);

            return new MedicalDbContext(builder.Options);
        }
    }
}
