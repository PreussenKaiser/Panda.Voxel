using Microsoft.Xna.Framework;
using PandaQuest.Configuration;
using PandaQuest.Extensions;
using PandaQuest.Models;

namespace PandaQuest.Generators;

public sealed class FiniteWorldGenerator : IWorldGenerator
{
	private readonly FiniteWorldConfiguration finiteWorldConfiguration;
	private readonly WorldConfiguration worldConfiguration;
	private readonly Chunk[,] chunks;

	private bool wasGenerated;
	private IEnumerable<BlockFace>? meshCache;

	public FiniteWorldGenerator(FiniteWorldConfiguration finiteWorldConfiguration, WorldConfiguration worldConfiguration)
	{
		this.finiteWorldConfiguration = finiteWorldConfiguration;
		this.worldConfiguration = worldConfiguration;

		this.chunks = new Chunk[(int)this.finiteWorldConfiguration.Dimensions.X, (int)this.finiteWorldConfiguration.Dimensions.Y];
	}

	public IEnumerable<Chunk> Chunks => this.chunks.Flatten();

	public IEnumerable<BlockFace> Mesh
		=> this.meshCache ??= this.Chunks
			.SelectMany(c => c.Blocks)
			.ToDictionary(kv => kv.Key, kv => kv.Value)
			.ToMesh();

	public void Generate()
	{
		if (this.wasGenerated)
		{
			return;
		}

		for (var x = 0; x < this.finiteWorldConfiguration.Dimensions.X; x++)
		{
			for (var y = 0; y < this.finiteWorldConfiguration.Dimensions.Y; y++)
			{
				var chunk = new Chunk(new Vector2(x, y), this.worldConfiguration);
				chunk.Load();

				this.chunks[x, y] = chunk;
			}
		}

		this.wasGenerated = true;
	}
}
