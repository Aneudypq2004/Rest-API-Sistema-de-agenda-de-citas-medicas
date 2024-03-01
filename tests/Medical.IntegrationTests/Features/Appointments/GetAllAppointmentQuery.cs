
using FluentAssertions;
using Medical.Application.Dtos.Appoinment.Request;
using System.Net.Http.Json;

namespace Medical.IntegrationTests.Features.Appointment
{
    public class GetAllAppointmentQuery : TestBase
    {
        [Fact]

        public async void ShouldReturnAllAppoinment()
        {
            // arrange

            var (client, userId) = await GetClientAsDefaultAsync();

            // act

            var appointmnet = await client.GetFromJsonAsync<IEnumerable<AppoinmentDto>>($"/api/appointment/{userId}");

            // assert

            appointmnet.Should().NotBeNullOrEmpty();

        }
    }
}
