using Panda.Extensions;
using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;

namespace Panda.Noise.Gradient;

/// <summary>
/// 2d gradient noise.
/// </summary>
public sealed class GradientNoise2(GradientNoiseConfiguration configuration) : INoise
{
	private readonly GradientNoiseConfiguration configuration = configuration;
	private readonly Random random = new(configuration.Seed);
	private readonly int[,] noiseMap = new int[(int)configuration.Size.X, (int)configuration.Size.Y];

	private bool wasGenerated;

	public int GetValue(int x, int y)
	{
		if (!this.wasGenerated)
		{
			this.Generate();
		}

		return this.noiseMap[x, y];
	}

	public int[,] Generate()
	{
		this.SetMarkers();
		this.noiseMap.Smoothen();

		this.wasGenerated = true;

		return this.noiseMap;
	}

	public void SetMarkers()
	{
		for (var x = 0; x < configuration.Size.X; x++)
		{
			for (var y = 0;  y < this.configuration.Size.Y; y++)
			{
				int value = this.random.Next(this.configuration.MaximumHeight);

				this.noiseMap[x, y] = value;
			}
		}
	}
}
