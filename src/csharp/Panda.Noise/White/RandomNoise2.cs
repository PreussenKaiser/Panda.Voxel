using Panda.Extensions;
using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;

namespace Panda.Noise.White;

public sealed class RandomNoise2(WhiteNoiseConfiguration configuration) : INoise2
{
	private readonly Random random = new(configuration.Seed);

	public float GetValue(float x, float y)
	{
		float target = x + y;

		float value = random
			.Next((int)target)
			.Normalize(-1, 1);

		return value;
	}
}
