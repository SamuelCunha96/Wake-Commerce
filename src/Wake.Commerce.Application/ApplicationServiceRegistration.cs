using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wake.Commerce.Infrastructure;
using Wake.Commerce.Application.DataServices;
using AutoMapper;
using Wake.Commerce.Application.AutoMapper;
using Wake.Commerce.Application.Behaviours;

namespace Wake.Commerce.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) 
        {
            RegisterMediatR(services);

            RegisterValidators(services);

            RegisterDataServices(services);

            RegisterMappers(services);

            services.AddInfrastructureServices(configuration);

            return services;
        }

        private static void RegisterDataServices(IServiceCollection services) 
        {
            services.AddScoped<DataSeeder>();
        }

        private static void RegisterMediatR(IServiceCollection services) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }

        private static void RegisterValidators(IServiceCollection services)
            => services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));

        private static void RegisterMappers(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new EntityToDto()); });
            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}