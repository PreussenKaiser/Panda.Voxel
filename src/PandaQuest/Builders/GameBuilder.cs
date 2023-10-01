using PandaQuest.Contexts;
using PanDI;
using PanDI.Extensions;

namespace PandaQuest.Builders;

public sealed class GameBuilder
{
	public readonly ServiceCollection Services;

	public GameBuilder(ServiceCollection? services = null)
	{
		this.Services = services ?? new ServiceCollection();
	}

	public GameBuilder ConfigureServices(Action<ServiceCollection> action)
	{
		action(this.Services);

		return this;
	}

	public IGame Build()
	{
		ServiceProvider serviceProvider = this.Services.BuildProvider();
		var game = new GameContext(serviceProvider);

		return game;
	}
}
