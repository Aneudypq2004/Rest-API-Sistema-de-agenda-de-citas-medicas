namespace Medical.Domain.Entities
{
    public class Doctor : User
    {

        public string? Specialty { get; set; }
        public string? LicenseNumber { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
