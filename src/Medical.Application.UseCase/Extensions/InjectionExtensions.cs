using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using System.Reflection;
using Medical.Application.UseCase.Commons.Behaviours;
using FluentValidation.AspNetCore;
using FluentValidation;

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

            return services;
        }
    }
}
