﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Exceptions
{
    public class Unathorized : Exception
    {
        public Unathorized(string message) : base(message)
        {
            
        }
    }
}
