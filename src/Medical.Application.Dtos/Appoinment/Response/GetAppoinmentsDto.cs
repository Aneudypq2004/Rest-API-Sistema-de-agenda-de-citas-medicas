﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Application.Dtos.Appoinment.Response
{
    public class GetAppoinmentsDto
    {
        public int Id { get; set; }

        public bool State { get; set; }

        public string? Description { get; set; }

        public DateTime AppointmentDate { get; set; }

    }
}
