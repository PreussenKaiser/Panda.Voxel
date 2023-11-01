using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using PandaQuest.Configuration;

namespace PandaQuest.Models;

public sealed class Chunk
{
	public readonly Vector2 Position;

	public Chunk(Vector2 position)
	{
	}

	public BlockCollection Blocks => this.blocks;

	public void Load()
	{
		for (var x = 0; x < Constants.CHUNK_SIZE; x++)
		{
			for (var y = 0; y < Constants.WORLD_HEIGHT; y++)
			{
				for (var z = 0; z < Constants.CHUNK_SIZE; z++)
				{
				}
			}
		}
	}
}
