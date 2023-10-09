using Panda.Noise.Abstractions;

namespace Panda.Noise.Gradient;

public sealed class GradientNoise2 : INoise
{
	private readonly Random random;

	public GradientNoise2(int seed)
	{
		this.random = new Random(seed);
	}

	public int GetValue(int x, int y)
	{
		throw new NotImplementedException();
	}
}
