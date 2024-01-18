using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Entities
{
    public class Patient : User
    {
        public Doctor Doctor { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
