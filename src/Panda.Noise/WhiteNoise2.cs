using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;

namespace Panda.Noise;

public sealed class WhiteNoise2(WhiteNoiseConfiguration configuration) : INoise2
{
	private readonly Random random = new(configuration.Seed);

	public float GetValue(float x, float y)
	{
		float value = this.random.Next((int)(x + y));

		return value;
	}
}
