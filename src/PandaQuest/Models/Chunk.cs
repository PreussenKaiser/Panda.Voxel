using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using PandaQuest.Configuration;

namespace PandaQuest.Models;

public sealed class Chunk
{
	public readonly Vector2 Position;
	public readonly BoundingBox BoundingBox;
	private readonly BlockCollection blocks;
	private readonly List<BlockFace> mesh;

	public Chunk(Vector2 position)
	{
		this.Position = position;
		this.BoundingBox = new BoundingBox(
			new Vector3(GetOffset(position.X) + Constants.CHUNK_SIZE, -1, GetOffset(position.Y)),
			new Vector3(GetOffset(position.X), Constants.WORLD_HEIGHT + 1, GetOffset(position.Y) + Constants.CHUNK_SIZE));

		this.blocks = new BlockCollection(new WorldConfiguration(Constants.CHUNK_SIZE, Constants.WORLD_HEIGHT));
		this.mesh = new List<BlockFace>();
	}

	public BlockCollection Blocks => this.blocks;

	public IEnumerable<BlockFace> Mesh => this.mesh;

	public void Load(INoise noise)
	{
		int xOffset = GetOffset(this.Position.X);
		int zOffset = GetOffset(this.Position.Y);
		
		for (var x = 0; x < Constants.CHUNK_SIZE; x++)
		{
			for (var y = 0; y < Constants.WORLD_HEIGHT; y++)
			{
				for (var z = 0; z < Constants.CHUNK_SIZE; z++)
				{
					int translatedX = x + xOffset;
					int translatedZ = z + zOffset;

					BlockIndex blockIndex = GetBlock(noise, translatedX, y, translatedZ);

					if (blockIndex != BlockIndex.Air)
					{
						var block = new Block(blockIndex);

						this.blocks[x, y, z] = block;
					}
				}
			}
		}
	}

	public static BlockIndex GetBlock(INoise noise, int x, int y, int z)
	{
		int noiseValue = noise.GetValue(x, z);
		int translatedY = y + noiseValue;

		return translatedY >= Constants.WORLD_HEIGHT ? BlockIndex.Air : BlockIndex.Dirt;
	}

	private static int GetOffset(float value)
	{
		return (int)value * Constants.CHUNK_SIZE;
	}
}
