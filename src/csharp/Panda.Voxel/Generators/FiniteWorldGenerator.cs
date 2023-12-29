using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using Panda.Voxel.Configuration;
using Panda.Voxel.Extensions;
using Panda.Voxel.Models;

namespace Panda.Voxel.Generators;

public sealed class FiniteWorldGenerator(INoise2 noise, FiniteWorldConfiguration finiteWorldConfiguration, WorldConfiguration worldConfiguration) : IWorldGenerator
{
	private readonly INoise2 noise = noise;
	private readonly FiniteWorldConfiguration finiteWorldConfiguration = finiteWorldConfiguration;
	private readonly WorldConfiguration worldConfiguration = worldConfiguration;
	private readonly Chunk[,] chunks = new Chunk[(int)finiteWorldConfiguration.Dimensions.X, (int)finiteWorldConfiguration.Dimensions.Y];

	private bool wasGenerated;
	private IEnumerable<BlockFace>? meshCache;

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
				var chunk = new Chunk(new Vector2(x, y), this.noise, this.worldConfiguration);
				chunk.Load();

				this.chunks[x, y] = chunk;
			}
		}

		this.wasGenerated = true;
	}
}
