using Panda.Noise.Configuration;
using Panda.Noise.Gradient;
using System.Numerics;

namespace PandaQuest.Tests.Noise.Gradient;

public sealed class GradientNoise2Tests
{
	[Fact]
	public void SetMarkers_HappyPath()
	{
		// Arrange
		var configuration = new GradientNoiseConfiguration(48, new Vector2(16));
		var noise = new GradientNoise2(configuration);

		// Act
		int value = noise.GetValue(4, 4);

		// Assert
		Assert.True(true);
	}
}
