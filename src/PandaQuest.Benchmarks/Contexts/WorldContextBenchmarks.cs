using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;
using PandaQuest.Contexts;

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
		this.worldContext.Update(new GameTime());
	}
}
