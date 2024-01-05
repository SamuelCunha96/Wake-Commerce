using Wake.Commerce.Shared.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wake.Commerce.Repository;
using Wake.Commerce.Shared;
using Wake.Commerce.Business.DataServices;

namespace Wake.Commerce.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration) 
        {
            RegisterMediatR(services);

            RegisterValidators(services);

            RegisterDataServices(services);

            services.AddRepositoryServices(configuration);

            services.AddSharedServices();

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
    }
}