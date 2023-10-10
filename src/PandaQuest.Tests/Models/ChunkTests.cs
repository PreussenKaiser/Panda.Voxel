using PandaQuest.Models;
using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using PandaQuest.Tests.Mocks;

namespace PandaQuest.Tests.Models;

public sealed class ChunkTests
{
	private readonly INoise noise = new MockNoise();

	[Theory]
	[InlineData(0, 0, -15, -15)]
	[InlineData(2, 2, 17, 17)]
	public void Generated_Blocks(float chunkX, float chunkY, float blockX, float blockY)
	{
		// Arrange
		var chunkPosition = new Vector2(chunkX, chunkY);
		var cornerLeftBlockPosition = new Vector2(blockX, blockY);
		var chunk = new Chunk(chunkPosition);

		// Act
		chunk.Load(this.noise);

		Block cornerLeftBlock = chunk.Blocks.Values.Last();
		var actualPosition = new Vector2(cornerLeftBlock.Position.X, cornerLeftBlock.Position.Z);

		// Assert
		Assert.Equal(cornerLeftBlockPosition, actualPosition);
	}
}
