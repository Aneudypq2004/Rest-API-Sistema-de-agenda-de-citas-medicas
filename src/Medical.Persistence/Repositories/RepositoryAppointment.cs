using Medical.Application.Contracts;
using Medical.Domain.Entities;
using Medical.Persistence.Context;
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
    }
}
