using System.Numerics;

namespace Panda.Noise.Configuration;

public sealed class GradientNoiseConfiguration
{
	public byte MaximumHeight { get; init; }

	public byte MaximumSlope { get; init; }

	public int Seed { get; init; }

	public Vector2 Size { get; init; }
}
