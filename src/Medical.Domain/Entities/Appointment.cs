using Medical.Domain.Core;

namespace Medical.Domain.Entities
{
    public class Appointment : BaseEntity
    {

        public bool State { get; set; }

        public string? Description { get; set; }

        public string? DoctorId { get; set; }
        public User? Doctor { get; set; }

        public string? PatientId { get; set; }
        public User? Patient { get; set; }

    }
}
