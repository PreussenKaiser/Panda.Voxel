using Microsoft.Extensions.DependencyInjection;
using Panda.Voxel.Builders;

namespace Panda.Voxel.Lifecycle;

public sealed class Game(IServiceProvider provider)
{
	private readonly IServiceProvider provider = provider;

	public static GameBuilder CreateDefaultBuilder()
	{
		var services = new ServiceCollection();

		return new GameBuilder(services);
	}

	public void Run()
	{
		using IServiceScope scope = this.provider.CreateScope();
		using var game = scope.ServiceProvider.GetService<IGame>();

		game?.Run();
	}
}
