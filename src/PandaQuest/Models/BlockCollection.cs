using Microsoft.Xna.Framework;
using PandaQuest.Configuration;

namespace PandaQuest.Models;

public readonly struct BlockCollection
{
	private readonly WorldConfiguration configuration;
	private readonly Block[,,] blocks;

	public BlockCollection(WorldConfiguration configuration)
	{
		this.configuration = configuration;
		this.blocks = new Block[configuration.ChunkSize, configuration.WorldHeight, configuration.ChunkSize];
	}

	public Block this[int x, int y, int z]
	{
		get
		{
			return y >= this.configuration.WorldHeight
				? new Block(BlockIndex.Air)
				: this.blocks[x, y, z];
		}
		set => this.blocks[x, y, z] = value;
	}

	public Block this[Vector3 position]
	{
		get => this[(int)position.X, (int)position.Y, (int)position.Z];
		set => this[(int)position.X, (int)position.Y, (int)position.Z] = value;
	}

	public bool IsEmpty(Vector3 position)
	{
		Block block = this[position];

		bool result = block.Id == BlockIndex.Air;

		return result;
	}
}
