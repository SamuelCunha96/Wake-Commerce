using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Wake.Commerce.Shared.AutoMapper;

namespace Wake.Commerce.Shared
{
    public static class SharedServiceRegistration
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            RegisterMappers(services);

            return services;
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new EntityToDto()); });
            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
