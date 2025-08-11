using DispatX.Dispatcher.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DispatX.Dispatcher;

public static class DependencyInjection
{
    public static IServiceCollection AddDispatcher(this IServiceCollection services)
    {


        services.AddSingleton<IDispatcher, InMemoryRequestDispatcher>();

        var assembly = Assembly.GetCallingAssembly();

        var handlerTypes = assembly.GetTypes()
                  .Where(t => !t.IsAbstract && !t.IsInterface)
                  .Select(t => new
                  {
                      Implementation = t,
                      Interfaces = t.GetInterfaces().Where(i => i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                  })
                  .Where(x => x.Interfaces.Any());

        foreach (var handler in handlerTypes)
        {
            foreach (var @interface in handler.Interfaces)
            {
                services.AddScoped(@interface, handler.Implementation);
            }
        }

        return services;
    }
}
