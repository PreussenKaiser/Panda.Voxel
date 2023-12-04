using Panda.Extensions;
using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;
using System.Numerics;

namespace Panda.Noise.Gradient;

/// <summary>
/// 2d gradient noise.
/// </summary>
public sealed class PerlinNoise2(PerlinNoiseConfiguration configuration) : INoise2
{
	private readonly PerlinNoiseConfiguration configuration = configuration;
	private readonly Random random = new(configuration.Seed);

	private int[]? permutationTable;

	public float GetValue(float x, float y)
	{
		float scaledX = x * this.configuration.Frequency;
		float scaledY = y * this.configuration.Frequency;

		int X = (int)Math.Floor(scaledX) & 255;
		int Y = (int)Math.Floor(scaledY) & 255;

		float xFloor = scaledX - (int)Math.Floor(scaledX);
		float yFloor = scaledY - (int)Math.Floor(scaledY);

		var topRight = new Vector2(xFloor - 1, yFloor - 1);
		var topLeft = new Vector2(xFloor, yFloor - 1);
		var bottomRight = new Vector2(xFloor - 1, yFloor);
		var bottomLeft = new Vector2(xFloor, yFloor);

		this.permutationTable ??= this.GeneratePermutation();
		int valueTopRight = this.permutationTable[this.permutationTable[X + 1] + Y + 1];
		int valueTopLeft = this.permutationTable[this.permutationTable[X] + Y + 1];
		int valueBottomRight = this.permutationTable[this.permutationTable[X + 1] + Y];
		int valueBottomLeft = this.permutationTable[this.permutationTable[X] + Y];

		float dotTopRight = Vector2.Dot(topRight, valueTopRight.ToConstantVector());
		float dotTopLeft = Vector2.Dot(topLeft, valueTopLeft.ToConstantVector());
		float dotBottomRight = Vector2.Dot(bottomRight, valueBottomRight.ToConstantVector());
		float dotBottomLeft = Vector2.Dot(bottomLeft, valueBottomLeft.ToConstantVector());

		float u = xFloor.Fade();
		float v = yFloor.Fade();

		float result = u.Lerp(
			v.Lerp(dotBottomLeft, dotTopLeft),
			v.Lerp(dotBottomRight, dotTopRight));

		return result;
	}

	private int[] GeneratePermutation()
	{
		var tableOne = new int[this.configuration.Permutations];
		for (var i = 0; i < this.configuration.Permutations; i++)
		{
			tableOne[i] = i;
		}

		this.random.Shuffle(tableOne);

		var tableTwo = new int[this.configuration.Permutations];
		for (var i = 0; i < this.configuration.Permutations; i++)
		{
			tableTwo[i] = tableOne[i];
		}

		return [..tableOne, ..tableTwo];
	}
}
