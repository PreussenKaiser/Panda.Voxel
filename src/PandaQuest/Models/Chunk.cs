using System.Numerics;

namespace PandaQuest.Models;

public sealed class Chunk
{
	public readonly Vector2 Position;

	// TODO: Use a more optimized data structure.
	private readonly List<Block> blocks;

	public Chunk(Vector2 position)
	{
		this.blocks = new List<Block>();
		this.Position = position;
	}

	public IEnumerable<Block> Blocks => this.blocks;

	public void Load()
	{
		float boundX = this.Position.X * Constants.CHUNK_SIZE;
		float boundNegativeX = boundX - Constants.CHUNK_SIZE + 1;
		float boundY = this.Position.Y * Constants.CHUNK_SIZE;
		float boundNegativeY = boundY - Constants.CHUNK_SIZE + 1;

		for (float x = boundX; x >= boundNegativeX; x--)
		{
			for (float y = boundY; y >= boundNegativeY; y--)
			{
				var blockPosition = new Vector3(x, 0, y);
				var block = new Block(blockPosition);

				this.blocks.Add(block);
			}
		}
	}
}
