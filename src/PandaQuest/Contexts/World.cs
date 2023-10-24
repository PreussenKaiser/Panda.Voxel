using Microsoft.Xna.Framework;
using PandaQuest.Generators;
using PandaQuest.Input;

namespace PandaQuest.Contexts;

public sealed class World
{
	public readonly InfiniteWorldGenerator Generation;

	private readonly Player player;

	public World(Player player, InfiniteWorldGenerator worldGenerator)
	{
		this.player = player;
		this.Generation = worldGenerator;
	}

	public void Update(GameTime gameTime)
	{
		this.Generation.Generate();
		this.player.Update(gameTime);
	}
}
