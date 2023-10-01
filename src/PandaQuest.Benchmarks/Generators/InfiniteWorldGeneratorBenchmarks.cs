using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;
using PandaQuest.Generators;
using PandaQuest.Input;
using PandaQuest.Input.CameraInput;
using PandaQuest.Input.Movement;

namespace PandaQuest.Benchmarks.Generators;

public class InfiniteWorldGeneratorBenchmarks
{
	private readonly IWorldGenerator worldGenerator;
	private readonly Player player;

	public InfiniteWorldGeneratorBenchmarks()
	{
		var mouseInput = new MouseInput(Vector2.Zero);
		var camera = new Camera(mouseInput, Vector3.Zero, 0);
		IMovement movement = new GroundedMovement();
		var player = new Player(camera, movement);

		this.worldGenerator = new InfiniteWorldGenerator(player);
		this.player = player;
	}

	[Benchmark]
	public void RenderChunks()
	{
		this.worldGenerator.Generate();
	}
}
