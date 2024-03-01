using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace Medical.IntegrationTests
{
    public class TestBase
    {
        protected CustomWebApplicationFactory application;

        public TestBase()
        {
            application = new CustomWebApplicationFactory();
        }

        protected async Task<(HttpClient client, string UserId)> CreateTestUser(string userName,string password, string[] roles)
        {
            var scope = application.Services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var newUser = new IdentityUser(userName);
            await userManager.CreateAsync(newUser, password);

            foreach (var role in roles)
            {
                await userManager.AddToRoleAsync(newUser , role);
            }

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");

            return (client, newUser.Id);
        }

        protected Task<(HttpClient client, string userId)> GetClientAsDefaultAsync() => CreateTestUser("TestUser", "12345678#Q", Array.Empty<string>());


        public Task<(HttpClient Client, string UserId)> GetClientAsAdmin() => CreateTestUser("user@admin.com", "PasswordSecured", new string[] { "Admin" });
    }
}
