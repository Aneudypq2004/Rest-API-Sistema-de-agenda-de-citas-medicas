﻿namespace Medical.Application.Dtos.Appoinment.Request
{
    public class AppoinmentCreationDto
    { 
        public bool State { get; set; }

        public string? Description { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}
