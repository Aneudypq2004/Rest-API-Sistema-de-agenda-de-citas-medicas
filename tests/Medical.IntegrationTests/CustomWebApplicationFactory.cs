using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Medical.IntegrationTests
{
   public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath("")
                .AddEnvironmentVariables()
                .Build();

        }
    }
}
