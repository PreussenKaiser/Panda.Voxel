using Microsoft.Xna.Framework;
using PandaQuest.Extensions;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Models;
using PandaQuest.Physics;
using PandaQuest.Time;

namespace PandaQuest.Contexts;

public sealed class World
{
	public readonly IWorldGenerator Generation;

	private readonly Player player;
	private readonly IPhysics physics;
	private readonly ITimeProvider timeProvider;

	public World(Player player, IPhysics physics, IWorldGenerator worldGenerator, ITimeProvider timeProvider)
	{
		this.player = player;
		this.physics = physics;
		this.Generation = worldGenerator;
		this.timeProvider = timeProvider;
	}

	private Chunk CurrentChunk
		=> this.Generation.Chunks.First(c => c.Position == this.player.Position.ToChunkPosition());

	public void Update(GameTime gameTime)
	{
		this.Generation.Generate();
		this.player.Update();
		this.physics.Update(this.CurrentChunk.Blocks, this.player, gameTime);
	}
}
