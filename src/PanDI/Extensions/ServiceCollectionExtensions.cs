namespace PanDI.Extensions;

public static class ServiceCollectionExtensions
{
	public static ServiceCollection AddSingleton<TService, TImplementation>(this ServiceCollection services)
	{
		var descriptor = new ServiceDescriptor(typeof(TService), typeof(TImplementation));

		services.Add(descriptor);

		return services;
	}

	public static ServiceProvider BuildProvider(this ServiceCollection services)
	{
		var serviceProvider = new ServiceProvider(services);

		return serviceProvider;
	}
}
