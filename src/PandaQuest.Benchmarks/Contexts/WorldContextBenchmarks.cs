using BenchmarkDotNet.Attributes;
using PandaQuest.Contexts;
using PandaQuest.Models;

namespace PandaQuest.Benchmarks.Contexts;

[MemoryDiagnoser]
public class WorldContextBenchmarks
{
	private readonly World worldContext;

	public WorldContextBenchmarks()
	{
		this.worldContext = Mocks.WorldContext;
	}

	[Benchmark]
	public void Update_World()
	{
		this.worldContext.Update(new GameContextTime());
	}
}
