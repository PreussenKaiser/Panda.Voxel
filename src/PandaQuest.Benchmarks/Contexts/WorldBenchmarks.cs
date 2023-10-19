using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;
using PandaQuest.Contexts;

namespace PandaQuest.Benchmarks.Contexts;

[MemoryDiagnoser]
public class WorldBenchmarks
{
	private readonly World worldContext;

	public WorldBenchmarks()
	{
		this.worldContext = Mocks.WorldContext;
	}

	[Benchmark]
	public void Update_World()
	{
		this.worldContext.Update(new GameTime());
	}
}
