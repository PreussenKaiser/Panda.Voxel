using Microsoft.Xna.Framework;
using PandaQuest.Configuration;
using PandaQuest.Extensions;

namespace PandaQuest.Models;

public sealed class Chunk
{
	public readonly Vector2 Position;

	private readonly WorldConfiguration configuration;
	private readonly IDictionary<Vector3, Block> blocks;

	public Chunk(Vector2 position, WorldConfiguration configuration)
	{
		this.Position = position;
		this.configuration = configuration;
		this.blocks = new Dictionary<Vector3, Block>();
	}

	public IDictionary<Vector3, Block> Blocks => this.blocks;

	public void Load()
	{
		for (var x = 0; x < this.configuration.ChunkSize; x++)
		{
			for (var y = 0; y < this.configuration.FlatLimit; y++)
			{
				for (var z = 0; z < this.configuration.ChunkSize; z++)
				{
					Vector3 globalPosition = new Vector3(x, y, z)
						.ToGlobalPosition(this.Position, this.configuration)
						.ToVector3(y);

					var block = new Block(BlockIndex.Dirt, globalPosition);

					this.blocks.Add(block.Position, block);
				}
			}
		}
	}
}
