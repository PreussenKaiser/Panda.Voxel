using PandaQuest.Models;
using Microsoft.Xna.Framework;
using Panda.Noise.Abstractions;
using PandaQuest.Tests.Mocks;

namespace PandaQuest.Tests.Models;

public sealed class ChunkTests
{
	private readonly INoise noise = new MockNoise();

	[Theory]
	[InlineData(0, 0, 0, 0)]
	[InlineData(2, 2, 32, 32)]
	public void Generated_Blocks(float chunkX, float chunkY, float blockX, float blockY)
	{
		// Arrange
		var chunkPosition = new Vector2(chunkX, chunkY);
		var chunk = new Chunk(chunkPosition);

		chunk.Load(this.noise);

		// Act
		bool containsBlock = chunk.Blocks.ContainsKey(new Vector3(blockX, 0, blockY));

		// Assert
		Assert.True(containsBlock);
	}
}
