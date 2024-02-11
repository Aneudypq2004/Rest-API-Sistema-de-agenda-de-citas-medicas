using Medical.Domain.Entities;
using Medical.Domain.Exceptions;
using Medical.Persistence.Repositories;

namespace Medical.UnitTest
{
    public class RepositoryAppoinmentTest : BaseContextTest
    {
        public RepositoryAppoinmentTest()
        {
            
        }
        [Fact]
        public void ShouldAddAnAppoinment()
        {

            // Arrange

            RepositoryAppointment repositoryAppointment = new(_context);

            Appointment appointment = new()
            {
                Description = "I hava a headache",
                DoctorId = "",
                State = true
            };

            // act


            // assertions

            Assert.False(true);
        }
    }
}
