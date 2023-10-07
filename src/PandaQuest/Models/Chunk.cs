using Microsoft.Xna.Framework;

namespace PandaQuest.Models;

public sealed class Chunk
{
	public readonly Vector2 Position;
	public readonly BoundingBox BoundingBox;

	private readonly IDictionary<Vector3, Block> blocks;

	public Chunk(Vector2 position)
	{
		this.Position = position;
		this.BoundingBox = new BoundingBox(
			new Vector3(GetOffset(position.X) + Constants.CHUNK_SIZE, -1, GetOffset(position.Y)),
			new Vector3(GetOffset(position.X), Constants.WORLD_HEIGHT + 1, GetOffset(position.Y) + Constants.CHUNK_SIZE));

		this.blocks = new Dictionary<Vector3, Block>();
	}

	public IDictionary<Vector3, Block> Blocks => this.blocks;

	public void Load()
	{
		int xOffset = GetOffset(this.Position.X);
		int zOffset = GetOffset(this.Position.Y);
		
		for (var x = 0; x < Constants.CHUNK_SIZE; x++)
		{
			var y = 0;

			for (var z = 0; z < Constants.CHUNK_SIZE; z++)
			{
				var blockPosition = new Vector3(x + xOffset, y, z + zOffset);
				var block = new Block(blockPosition);

				this.blocks.Add(blockPosition, block);
			}
		}
	}

	private static int GetOffset(float value)
	{
		return (int)value * Constants.CHUNK_SIZE;
	}
}
