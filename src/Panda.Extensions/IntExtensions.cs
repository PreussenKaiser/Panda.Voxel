using System.Numerics;

namespace Panda.Extensions;

public static class IntExtensions
{
	public static Vector2 ToConstantVector(this int i)
	{
		var h = i & 3;

		Vector2 result;
		if (h == 0)
		{
			result = new Vector2(1);
		}
		else if (h == 1)
		{
			result = new Vector2(-1, 1);
		}
		else if (h == 2)
		{
			result = new Vector2(-1);
		}
		else
		{
			result = new Vector2(1, -1);
		}

		return result;
	}

	public static float Normalize(this int value, int min, int max)
	{
		float result = ((value - min) / (max - min)) * 2 - 1;

		return result;
	}
}
