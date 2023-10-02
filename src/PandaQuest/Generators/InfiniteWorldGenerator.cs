using System.Numerics;
using PandaQuest.Extensions;
using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Generators;

public sealed class InfiniteWorldGenerator : IWorldGenerator
{
	private readonly Player player;
	private readonly List<Chunk> activeChunks;
	private readonly byte maxChunks;

	public InfiniteWorldGenerator(Player player)
	{
		this.player = player;
		this.maxChunks = Constants.RENDER_DISTANCE * 2 + 1;
		this.activeChunks = new List<Chunk>(this.maxChunks * this.maxChunks);
	}

	public IEnumerable<Block> Blocks => this.activeChunks.SelectMany(a => a.Blocks.Values);

	public void Generate()
	{
		this.BuildTerrain();
		this.BuildMesh();
	}

	private void BuildTerrain()
	{
		var playerPosition = this.player.Position.ToChunkPosition();

		float chunkBoundX = playerPosition.X + Constants.RENDER_DISTANCE;
		float chunkBoundNegativeX = playerPosition.X - Constants.RENDER_DISTANCE;
		float chunkBoundY = playerPosition.Y + Constants.RENDER_DISTANCE;
		float chunkBoundNegativeY = playerPosition.Y - Constants.RENDER_DISTANCE;

		for (float x = chunkBoundX; x >= chunkBoundNegativeX; x--)
		{
			Chunk? removeChunkX = this.activeChunks.FirstOrDefault(
				c => c.Position.X > chunkBoundX
				|| c.Position.X < chunkBoundNegativeX);

			if (removeChunkX is not null)
			{
				this.activeChunks.Remove(removeChunkX);
			}

			for (float y = chunkBoundY; y >= chunkBoundNegativeY; y--)
			{
				Chunk? removeChunkY = this.activeChunks.FirstOrDefault(
					c => c.Position.Y > chunkBoundY
					|| c.Position.Y < chunkBoundNegativeY);

				if (removeChunkY is not null)
				{
					this.activeChunks.Remove(removeChunkY);
				}

				var chunkPosition = new Vector2(x, y);

				if (this.activeChunks.Any(c => c.Position == chunkPosition))
				{
					continue;
				}

				this.LoadChunk(chunkPosition);
			}
		}
	}

	// TODO: Actually build a mesh.
	private void BuildMesh()
	{
		var blocksFlattened = (Dictionary<Vector3, Block>)this.activeChunks
			.SelectMany(c => c.Blocks)
			.ToDictionary(kv => kv.Key, kv => kv.Value);

		foreach (var pair in blocksFlattened)
		{
			Block block = pair.Value;

			bool topBlock = blocksFlattened.ContainsKey(new Vector3(block.Position.X, block.Position.Y + 1, block.Position.Z));
			bool bottomBlock = blocksFlattened.ContainsKey(new Vector3(block.Position.X, block.Position.Y - 1, block.Position.Z));
			bool leftBlock = blocksFlattened.ContainsKey(new Vector3(block.Position.X + 1, block.Position.Y, block.Position.Z));
			bool rightBlock = blocksFlattened.ContainsKey(new Vector3(block.Position.X - 1, block.Position.Y, block.Position.Z));
			bool frontBlock = blocksFlattened.ContainsKey(new Vector3(block.Position.X, block.Position.Y, block.Position.Z + 1));
			bool backBlock = blocksFlattened.ContainsKey(new Vector3(block.Position.X, block.Position.Y, block.Position.Z - 1));

			if (!topBlock)
			{
				block.EnableFace(CubeFace.Top);
			}

			if (!bottomBlock)
			{
				block.EnableFace(CubeFace.Bottom);
			}

			if (!leftBlock)
			{
				block.EnableFace(CubeFace.Left);
			}

			if (!rightBlock)
			{
				block.EnableFace(CubeFace.Right);
			}

			if (!frontBlock)
			{
				block.EnableFace(CubeFace.Front);
			}

			if (!backBlock)
			{
				block.EnableFace(CubeFace.Back);
			}
		}
	}

	private void LoadChunk(Vector2 position)
	{
		var newChunk = new Chunk(position);
		newChunk.Load();

		this.activeChunks.Add(newChunk);
	}
}
