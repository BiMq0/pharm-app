using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using InventarioFarmacia_Front.Services;

namespace InventarioFarmacia_Front.Handlers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            var assembly = typeof(IProductoService).Assembly;
            Console.WriteLine($"Assembly: {assembly.FullName}");
            var types = assembly.GetTypes().Where(t => t.Name.EndsWith("Service"));
            var classes = types.Where(t => t.IsClass && !t.IsAbstract);
            var interfaces = types.Where(t => t.IsInterface);
            foreach (var @class in classes)
            {
                var @interface = interfaces.FirstOrDefault(i => i.IsAssignableFrom(@class));
                if (@interface != null)
                {
                    Console.WriteLine($"Registering service: {@class.FullName} as {@interface.FullName}");
                    services.AddScoped(@interface, @class);
                }
            }
            return services;
        }
    }
}