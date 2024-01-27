namespace Medical.Application.Dtos.Appoinment.Request
{
    public class AppoinmentDto
    {

        public int Id { get; set; }

        public string? State { get; set; }

        public string? Description { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}
