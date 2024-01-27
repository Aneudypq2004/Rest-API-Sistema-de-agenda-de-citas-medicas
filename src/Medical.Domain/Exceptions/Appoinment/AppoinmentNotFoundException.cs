using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Exceptions.Appoinment
{
    public class AppoinmentNotFoundException : NotFoundException
    {
        public AppoinmentNotFoundException() : base("The Appointment does not exists")
        {
        }
    }
}
