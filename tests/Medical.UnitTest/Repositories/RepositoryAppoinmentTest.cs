using Medical.Application.Contracts.Persistence;
using Medical.Domain.Entities;
using Medical.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medical.UnitTest.Repositories
{
    public class RepositoryAppoinmentTest : BaseContextTest
    {
        private readonly IUnitOfWork unitOfWork;
        
        public RepositoryAppoinmentTest()
        {
            unitOfWork = new UnitOfWork(_context);     
        }

        [Fact]
        public async void ShouldAddAnAppoinment()
        {
            // Arrange

            Appointment appointment = new()
            {
                Description = "I hava a headache",
                AppointmentDate = DateTime.Now.AddDays(1),
                DoctorId = "DoctorTest",
                State = true
            };

            unitOfWork.AppointmentRepository.CreateAppointment(appointment);

            // act

            await unitOfWork.SaveChanges();

            // assertions

            Assert.Equal(6, await _context.Appointments!.CountAsync());
        }

        [Theory]
        [InlineData("Doctor1", 1)]
        public async void ShouldReturnOneApoinmentWithValidId(string doctorId, int appointmentId)
        {
            var appoinment = await unitOfWork.AppointmentRepository.GetAppointmentById(doctorId, appointmentId);

            Assert.IsType<Appointment>(appoinment);

            Assert.Equal(appointmentId, appoinment.Id);
        }

        [Theory]
        [InlineData("Doctor1", 14)]
        [InlineData("Invalid doctor id", 1)]
        public async void ShouldReturnNullWithInvalidAppoinmentIdOrInvalidDoctorId(string doctorId, int appoinmentId)
        {
            var appoinment = await unitOfWork.AppointmentRepository.GetAppointmentById(doctorId, appoinmentId);

            Assert.Null(appoinment);
        }

        [Fact]
        public async void ShouldDeleteOneAppoinment()
        {
            Appointment appointment = new()
            {
                Id = 1,
                Description = "I hava a headache",
                AppointmentDate = DateTime.Now.AddDays(1),
                DoctorId = "DoctorTest",
                State = true

            };

            // act

            unitOfWork.AppointmentRepository.DeleteAppointment(appointment);

            await unitOfWork.SaveChanges();

            var actual = await _context.Appointments!.CountAsync();

            Assert.Equal(4, actual);
        }

    }
}
