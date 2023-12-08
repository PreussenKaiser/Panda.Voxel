namespace Panda.Extensions;

public static class FloatExtensions
{
	/// <summary>
	/// Scales a <paramref name="value"/> between -1 and 1 to the <paramref name="scalar"/>.
	/// </summary>
	public static float Scale(this float value, float scalar)
	{
		float result = (value + 1) / 2 * scalar;

		return result;
	}
}
