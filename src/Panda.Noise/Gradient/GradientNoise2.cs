using Panda.Noise.Abstractions;

namespace Panda.Noise.Gradient;

/// <summary>
/// Custom 2d gradient noise.
/// </summary>
public sealed class GradientNoise2 : INoise
{
	private readonly Random random;

	public GradientNoise2(int seed)
	{
		this.random = new Random(seed);
	}

	public int GetValue(int x, int y)
	{
		return 1;
	}
}
