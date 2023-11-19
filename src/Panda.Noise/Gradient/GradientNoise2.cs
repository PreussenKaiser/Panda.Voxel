using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;

namespace Panda.Noise.Gradient;

/// <summary>
/// 2d gradient noise.
/// </summary>
public sealed class GradientNoise2 : INoise
{
	private readonly GradientNoiseConfiguration configuration;
	private readonly Random random;
	private readonly byte[,] noiseMap;

	public GradientNoise2(GradientNoiseConfiguration configuration)
	{
		this.configuration = configuration;
		this.random = new Random(configuration.Seed);
		this.noiseMap = new byte[(int)configuration.Size.X, (int)configuration.Size.Y];
	}

	public int GetValue(int x, int y)
	{
		return 1;
	}
}
