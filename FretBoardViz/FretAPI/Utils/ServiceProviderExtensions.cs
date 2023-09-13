// I have two classes implementing the same interface. 
namespace FretAPI.Utils;
public static class ServiceProviderExtensions
{
    public static TService GetNamedService<TService>(this IServiceProvider provider, string name)
    {
        var services = provider.GetServices<TService>();
        var service = services.FirstOrDefault(s => s.GetType().Name == name);
        if (service == null)
        {
            throw new InvalidOperationException($"Service with name '{name}' not found.");
        }
        return service;
    }
}

