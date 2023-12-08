using Microsoft.Xna.Framework;
using Panda.Voxel.Configuration;
using Panda.Voxel.Extensions;

namespace Panda.Voxel.Tests.Game.Extensions;

public sealed class Vector3Extensions
{
	private readonly WorldConfiguration worldConfiguration = new WorldConfiguration
	{
		ChunkSize = 16,
		WorldHeight = 128,
		FlatLimit = 48,
	};

	[Theory]
	[InlineData(0, 0, 0, 0)]
	[InlineData(.4f, -17, 0, -1)]
	public void ToLocalPosition_HappyPath(float globalX, float globalY, float localX, float localY)
	{
		// Arrange
		var globalPosition = new Vector3(globalX, 0, globalY);
		var expectedLocalPosition = new Vector2(localX, localY);

		// Act
		Vector2 actualLocalPosition = globalPosition.ToLocalPosition(worldConfiguration);

		// Assert
		Assert.Equal(expectedLocalPosition, actualLocalPosition);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, 0, 0)]
	[InlineData(0, 0, 1, 1, 16, 16)]
	[InlineData(12, 2, 3, 4, 60, 66)]
	public void ToGlobalPosition_HappyPath(float localX, float localY, float chunkX, float chunkY, float globalX, float globalY)
	{
		// Arrange
		var localPosition = new Vector3(localX, 1, localY);
		var chunkPosition = new Vector2(chunkX, chunkY);
		var expectedGlobalPosition = new Vector2(globalX, globalY);

		// Act
		Vector2 actualGlobalPosition = localPosition.ToGlobalPosition(chunkPosition, worldConfiguration);

		// Assert
		Assert.Equal(expectedGlobalPosition, actualGlobalPosition);
	}
}
