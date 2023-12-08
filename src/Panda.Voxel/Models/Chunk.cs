using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using Panda.Voxel.Configuration;
using Panda.Voxel.Extensions;

namespace Panda.Voxel.Models;

public sealed class Chunk(Vector2 position, INoise2 noise, WorldConfiguration configuration)
{
	public readonly Vector2 Position = position;

	private readonly INoise2 noise = noise;
	private readonly WorldConfiguration configuration = configuration;
	private readonly Dictionary<Vector3, Block> blocks = [];

	public IDictionary<Vector3, Block> Blocks => this.blocks;

	public void Load()
	{
		for (var x = 0; x < this.configuration.ChunkSize; x++)
		{
			for (var y = 0; y < this.configuration.WorldHeight; y++)
			{
				for (var z = 0; z < this.configuration.ChunkSize; z++)
				{
					Vector3 globalPosition = new Vector3(x, y, z)
						.ToGlobalPosition(this.Position, this.configuration)
						.ToVector3(y);

					var index = this.noise.GetBlockIndex(globalPosition, this.configuration);

					if (index != BlockIndex.Air)
					{
						var block = new Block(index, globalPosition);
						
						this.blocks.Add(block.Position, block);
					}

				}
			}
		}
	}
}
