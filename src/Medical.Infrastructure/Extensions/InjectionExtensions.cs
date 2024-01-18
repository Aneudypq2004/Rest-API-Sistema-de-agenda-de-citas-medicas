using Medical.Application.Contracts.Infrastructure;
using Medical.Infrastructure.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
