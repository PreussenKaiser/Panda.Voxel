using PandaQuest.Models;
using System.Numerics;

namespace PandaQuest.Tests.Models;

public sealed class ChunkTests
{
	[Theory]
	[InlineData(0, 0, -15, -15)]
	[InlineData(2, 2, 17, 17)]
	public void GeneratedBlocks(float chunkX, float chunkY, float blockX, float blockY)
	{
		// Arrange
		var chunkPosition = new Vector2(chunkX, chunkY);
		var cornerLeftBlockPosition = new Vector2(blockX, blockY);
		var chunk = new Chunk(chunkPosition);

		// Act
		chunk.Load();

		Block cornerLeftBlock = chunk.Blocks.Values.Last();
		var actualPosition = new Vector2(cornerLeftBlock.Position.X, cornerLeftBlock.Position.Z);

		// Assert
		Assert.Equal(cornerLeftBlockPosition, actualPosition);
	}
}
