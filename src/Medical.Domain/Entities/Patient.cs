namespace Medical.Domain.Entities
{
    public class Patient : User
    {
        public Doctor Doctor { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
