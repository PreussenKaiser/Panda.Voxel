using System.Numerics;

namespace Panda.Noise.Configuration;

public sealed class GradientNoiseConfiguration(byte maximumHeight, Vector2 size, int seed = 0)
{
	public byte MaximumHeight => maximumHeight;

	public int Seed => seed;

	public Vector2 Size => size;
}
