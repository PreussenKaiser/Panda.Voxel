using Microsoft.Extensions.DependencyInjection;
using PandaQuest.Builders;

namespace PandaQuest.Lifecycle;

public sealed class Game
{
	private readonly IServiceProvider provider;

	public Game(IServiceProvider provider)
	{
		this.provider = provider;
	}

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
