using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using PandaQuest.Configuration;
using PandaQuest.Extensions;

namespace PandaQuest.Models;

public sealed class Chunk
{
	public readonly Vector2 Position;

	private readonly INoise noise;
	private readonly WorldConfiguration configuration;
	private readonly IDictionary<Vector3, Block> blocks;

	public Chunk(Vector2 position, INoise noise, WorldConfiguration configuration)
	{
		this.Position = position;

		this.noise = noise;
		this.configuration = configuration;
		this.blocks = new Dictionary<Vector3, Block>();
	}

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
