using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Models;
using PandaQuest.Physics;
using PandaQuest.Time;

namespace PandaQuest.Contexts;

public sealed class WorldContext
{
	private readonly Player player;
	private readonly IPhysics physics;
	private readonly IWorldGenerator generation;
	private readonly ITimeProvider timeProvider;

	public WorldContext(Player player, IPhysics physics, IWorldGenerator worldGenerator, ITimeProvider timeProvider)
	{
		this.player = player;
		this.physics = physics;
		this.generation = worldGenerator;
		this.timeProvider = timeProvider;
	}

	public IEnumerable<Block> Blocks => this.generation.Blocks;

	public void Update(GameContextTime gameTime)
	{
		this.generation.Generate();
		this.player.Update(gameTime);
		this.physics.Update(this.generation.Blocks, this.player, gameTime);
	}
}
