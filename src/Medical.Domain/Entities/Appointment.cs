namespace Medical.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public bool State { get; set; }

        public string? Description { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string? DoctorId { get; set; }
        public User? Doctor { get; set; }

    }
}
