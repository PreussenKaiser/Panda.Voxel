using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;
using SimpleNoise = SimplexNoise.Noise;

namespace Panda.Noise.Gradient;

/// <summary>
/// 2d gradient noise.
/// </summary>
public sealed class GradientNoise2(GradientNoiseConfiguration configuration) : INoise
{
	private readonly GradientNoiseConfiguration configuration = configuration;
	private readonly Random random = new(configuration.Seed);

	public int GetValue(int x, int y)
	{
		SimpleNoise.Seed = this.configuration.Seed;
		
		float value = SimpleNoise.CalcPixel2D(x, y, 2);

		return (int)value;
	}
}
