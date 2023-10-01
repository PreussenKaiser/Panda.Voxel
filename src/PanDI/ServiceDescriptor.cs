using System.Diagnostics.CodeAnalysis;

namespace PanDI;

public readonly struct ServiceDescriptor
{
	public readonly Type ServiceType;
	public readonly Type ImplementationType;
	public readonly ServiceLifetime ServiceLifetime;

	public ServiceDescriptor(
		Type serviceType,
		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType,
		ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
	{
		this.ServiceType = serviceType;
		this.ImplementationType = implementationType;
		this.ServiceLifetime = serviceLifetime;
	}
}
