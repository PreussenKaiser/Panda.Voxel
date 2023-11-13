using Microsoft.Extensions.DependencyInjection;
using PandaQuest.Lifecycle;

namespace PandaQuest.Builders;

public sealed class GameBuilder
{
	public readonly IServiceCollection Services;

	public GameBuilder(IServiceCollection? services = null)
	{
		this.Services = services ?? new ServiceCollection();
	}

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
