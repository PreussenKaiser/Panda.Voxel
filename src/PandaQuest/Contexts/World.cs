using Microsoft.Xna.Framework;
using PandaQuest.Extensions;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Models;
using PandaQuest.Physics;

namespace PandaQuest.Contexts;

public sealed class World
{
	public readonly IWorldGenerator Generation;

	private readonly Player player;
	private readonly IPhysics physics;

	public World(Player player, IPhysics physics, IWorldGenerator worldGenerator)
	{
		this.player = player;
		this.physics = physics;
		this.Generation = worldGenerator;
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
