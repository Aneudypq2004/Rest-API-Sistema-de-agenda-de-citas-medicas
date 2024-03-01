using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository AppointmentRepository { get; }
        Task<int> SaveChanges();
    }
}
