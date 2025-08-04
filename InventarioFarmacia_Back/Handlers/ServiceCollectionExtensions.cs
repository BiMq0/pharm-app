using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InventarioFarmacia_Back
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScopedRepositories(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            var interfaces = types.Where(t => t.IsInterface && t.Name.EndsWith("Repository"));

            foreach (var itf in interfaces)
            {
                var implementation = types.FirstOrDefault(t => itf.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
                if (implementation != null)
                {
                    services.AddScoped(itf, implementation);
                }
            }
            return services;
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var interfaces = types.Where(t => t.IsInterface && t.Name.EndsWith("Service"));
            foreach (var itf in interfaces)
            {
                var implementation = types.FirstOrDefault(t => itf.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
                if (implementation != null)
                {
                    services.AddScoped(itf, implementation);
                }
            }
            return services;
        }

        public static IServiceCollection AddScopedMappers(this IServiceCollection services)
        {
            // todavia deberia ser implementado cuando se agreguen los demas mappers
            services.AddScoped<ProductMapper>();
            return services;
        }
    }
}