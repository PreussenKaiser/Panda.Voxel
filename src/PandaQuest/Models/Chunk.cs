﻿using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;

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

					var blockIndex = GetBlock(noise, translatedX, y, translatedZ);

					if (blockIndex != BlockIndex.Air)
					{
						var blockPosition = new Vector3(translatedX, y, translatedZ);
						var block = new Block(blockIndex, blockPosition);

						this.blocks.Add(blockPosition, block);
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
