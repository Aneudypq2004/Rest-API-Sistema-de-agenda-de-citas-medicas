using Medical.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medical.Persistence.Context
{
    public class MedicalDbContext : IdentityDbContext<User>
    {
        public MedicalDbContext(DbContextOptions<MedicalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>(u => { u.ToTable("Roles"); });

            builder.Entity<IdentityUser>(u =>
            {
                u.ToTable("Users");
            });

            builder.Entity<IdentityUserRole<string>>(u =>
            {
                u.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(u =>
            {
                u.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(u =>
            {
                u.ToTable("UserLogin");
            });

            builder.Entity<IdentityRoleClaim<string>>(rc =>
            {
                rc.ToTable("UserRolesClaims");
            });

            builder.Entity<IdentityUserToken<string>>(ut =>
            {
                ut.ToTable("UserToken");
            });

        }

        // DAPPER
        //public IDbConnection CreateConnection => new SqlConnection(_configuraton.GetConnectionString("")!);

        public DbSet<Appointment>? Appointments { get; set; }

    }
}
