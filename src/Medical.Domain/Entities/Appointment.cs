using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public string? State { get; set; }

        public DateTime AppointmentDate { get; set; }

        public User Patient { get; set; }

    }
}
