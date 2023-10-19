using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using PandaQuest.Extensions;
using PandaQuest.Input;
using PandaQuest.Models;

namespace PandaQuest.Generators;

public sealed class InfiniteWorldGenerator
{
	private readonly Player player;
	private readonly List<Chunk> activeChunks;
	private readonly INoise noise;

	public InfiniteWorldGenerator(Player player, INoise noise)
	{
		this.player = player;
		this.noise = noise;

		byte maxChunks = Constants.RENDER_DISTANCE * 2 + 1;
		this.activeChunks = new List<Chunk>(maxChunks * maxChunks);
	}

	public IEnumerable<Chunk> Chunks => this.activeChunks;

	public void Generate()
	{
		Vector2 playerPosition = this.player.Position.ToChunkPosition();

		float chunkBoundX = playerPosition.X + Constants.RENDER_DISTANCE;
		float chunkBoundNegativeX = playerPosition.X - Constants.RENDER_DISTANCE;
		float chunkBoundY = playerPosition.Y + Constants.RENDER_DISTANCE;
		float chunkBoundNegativeY = playerPosition.Y - Constants.RENDER_DISTANCE;

		Chunk? removeChunk = this.activeChunks.FirstOrDefault(
			c => c.Position.X > chunkBoundX
			|| c.Position.X < chunkBoundNegativeX
			|| c.Position.Y > chunkBoundY
			|| c.Position.Y < chunkBoundNegativeY);

		if (removeChunk is not null)
		{
			this.activeChunks.Remove(removeChunk);
		}

		for (float x = chunkBoundX; x >= chunkBoundNegativeX; x--)
		{
			for (float y = chunkBoundY; y >= chunkBoundNegativeY; y--)
			{
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
		newChunk.Load(this.noise);

		this.activeChunks.Add(newChunk);
	}
}
