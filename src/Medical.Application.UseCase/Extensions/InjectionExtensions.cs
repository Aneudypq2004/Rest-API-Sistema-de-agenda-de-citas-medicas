using FluentValidation;
using MediatR;
using Medical.Application.UseCase.Commons.Behaviours;
using Medical.Domain.Entities;
using Medical.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Medical.Application.UseCase.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddIdentity<Doctor, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;

            })
           .AddDefaultTokenProviders()
           .AddEntityFrameworkStores<MedicalDbContext>();



            return services;

        }
    }
}
