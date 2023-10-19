using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Models;
using PandaQuest.Physics;

namespace PandaQuest.Benchmarks.Physics;

[MemoryDiagnoser]
public class OverworldPhysicsBenchmarks
{
	private readonly IPhysics physics;
	private readonly IWorldGenerator generator;
	private readonly Player player;

	public OverworldPhysicsBenchmarks()
	{
		this.physics = Mocks.Physics;
		this.generator = Mocks.WorldGenerator;
		this.player = Mocks.Player;

		this.generator.Generate();
	}

	[Benchmark]
	public void Update_Physics()
	{
		BlockCollection blocks = this.generator.Chunks.SelectMany(c => c.Blocks);

		this.physics.Update(blocks, this.player, new GameTime());
	}
}
