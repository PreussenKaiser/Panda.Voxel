using Microsoft.Xna.Framework;
using PandaQuest.Extensions;

namespace PandaQuest.Tests.Extensions;

public sealed class Vector3Extensions
{
	[Theory]
	[InlineData(0f, 0f, 0, 0f)]
	[InlineData(.4f, -17, 0, -1)]
	public void Translate_Position(float playerX, float playerZ, float chunkX, float chunkY)
	{
		// Arrange
		var playerPosition = new Vector3(playerX, 0, playerZ);
		var chunkPosition = new Vector2(chunkX, chunkY);

		// Act
		var translatedPosition = playerPosition.ToChunkPosition();

		// Assert
		Assert.Equal(translatedPosition, chunkPosition);
	}

	[Theory]
	[InlineData(32, 32, 0, 0)]
	public void Absolute_To_Local_Position(
		int absoluteX, int absoluteZ,
		int localX, int localZ)
	{
		// Arrange
		var absolutePosition = new Vector3(absoluteX, 0, absoluteZ);
		var localPosition = new Vector3(localX, 0, localZ);

		// Act

		// Assert
	}
}
