namespace Panda.Extensions.Math;

public static class MathHelper
{
	public static float InterpolateQuintic(float value)
	{
		return value * value * value * (value * (value * 6 - 15) + 10);
	}

	public static float LinearInterpolate(float a, float b, float t)
	{
		return a + t * (b - a);
	}

	public static float Gradient(int seed, int xPrimed, int yPrimed, float xd, float yd)
	{
		int hash = Hash(seed, xPrimed, yPrimed);
		hash ^= hash >> 15;
		hash &= 127 << 1;

		float xg = Gradients.Two[hash];
		float yg = Gradients.Two[hash | 1];

		return xd * xg + yd * yg;
	}

	public static int Hash(int seed, int x, int y)
	{
		int hash = seed ^ x ^ y;
		hash *= 0x27d4eb2d;

		return hash;
	}

	public static int FastFloor(float value)
	{
		return value >= 0 ? (int)value : (int)value - 1;
	}
}
