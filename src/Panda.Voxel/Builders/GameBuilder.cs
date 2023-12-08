using Microsoft.Extensions.DependencyInjection;
using Panda.Voxel.Lifecycle;

namespace Panda.Voxel.Builders;

public sealed class GameBuilder(IServiceCollection? services = null)
{
	public readonly IServiceCollection Services = services ?? new ServiceCollection();

	public GameBuilder ConfigureServices(Action<IServiceCollection> action)
	{
		action(this.Services);

		return this;
	}

	public Game Build()
	{
		IServiceProvider serviceProvider = this.Services.BuildServiceProvider();
		var game = new Game(serviceProvider);

		return game;
	}
}
