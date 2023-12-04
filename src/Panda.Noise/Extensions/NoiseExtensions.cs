using Panda.Noise.Abstractions;
using System.Numerics;

namespace Panda.Noise.Extensions;

public static class NoiseExtensions
{
	public static float GetValue(this INoise2 noise, Vector2 vector)
	{
		float value = noise.GetValue(vector.X, vector.Y);

		return value;
	}

	public static float[,] GenerateNoiseMap(this INoise2 noise, int width, int height)
	{
		var map = new float[width, height];
		for (var x = 0; x < width; x++)
		{
			for (var y = 0; y < height; y++)
			{
				map[x, y] = noise.GetValue(x, y);
			}
		}

		return map;
	}
}
