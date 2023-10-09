using BenchmarkDotNet.Attributes;
using PandaQuest.Generators;
using PandaQuest.Input;

namespace PandaQuest.Benchmarks.Generators;

[MemoryDiagnoser]
public class InfiniteWorldGeneratorBenchmarks
{
	private readonly IWorldGenerator worldGenerator;
	private readonly Player player;

	public InfiniteWorldGeneratorBenchmarks()
	{
		this.worldGenerator = Mocks.WorldGenerator;
		this.player = Mocks.Player;
	}

	[Benchmark]
	public void RenderChunks()
	{
		this.worldGenerator.Generate();
	}
}
