using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Entities
{
    public class Doctor : User
    {
        public ICollection<Patient>? Patients { get; set; }
    }
}
