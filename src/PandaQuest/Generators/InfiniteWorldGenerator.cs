using Microsoft.Xna.Framework;
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

	public IEnumerable<Block> Blocks => this.activeChunks.SelectMany(a => a.Blocks);

	public void Generate()
	{
		var playerPosition = this.player.Position.ToChunkPosition();
		playerPosition.Round();

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

	private void LoadChunk(Vector2 position)
	{
		var newChunk = new Chunk(position);
		newChunk.Load();

		this.activeChunks.Add(newChunk);
	}
}
