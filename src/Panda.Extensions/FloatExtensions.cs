namespace Panda.Extensions;

public static class FloatExtensions
{
	public static float Fade(this float value)
	{
		return ((6 * value - 15) * value + 10) * value * value * value;
	}

	/// <summary>
	/// Linear interpolation.
	/// </summary>
	public static float Lerp(this float n, float x, float y)
	{
		if (n < 0 || n > 1)
		{
			throw new ArgumentException("Number must be between 0.0 and 1.0", nameof(n));
		}

		return x + n * (y - x);
	}

	public static float Power(this float value, int amount)
	{
		float result = value;
		do
		{
			result *= value;
		}
		while (amount-- > 0);

		return result;
	}
}
