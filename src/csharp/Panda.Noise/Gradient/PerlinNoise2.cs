using Panda.Noise.Abstractions;
using Panda.Noise.Configuration;
using Panda.Extensions.Math;

namespace Panda.Noise.Gradient;

public sealed class PerlinNoise2(PerlinNoiseConfiguration configuration) : INoise2
{
	private readonly PerlinNoiseConfiguration configuration = configuration;

	public float GetValue(float x, float y)
	{
		this.Scale(ref x, ref y);

		int x0 = MathHelper.FastFloor(x);
		int y0 = MathHelper.FastFloor(y);

		var xd0 = (float)(x - x0);
		var yd0 = (float)(y - y0);
		var xd1 = xd0 - 1;
		var yd1 = yd0 - 1;

		float xs = MathHelper.InterpolateQuintic(xd0);
		float ys = MathHelper.InterpolateQuintic(yd0);

		x0 *= Prime.X;
		y0 *= Prime.Y;
		int x1 = x0 + Prime.X;
		int y1 = y0 + Prime.Y;

		float xf0 = MathHelper.LinearInterpolate(
			MathHelper.Gradient(this.configuration.Seed, x0, y0, xd0, yd0),
			MathHelper.Gradient(this.configuration.Seed, x1, y0, xd1, yd0),
			xs);

		float xf1 = MathHelper.LinearInterpolate(
			MathHelper.Gradient(this.configuration.Seed, x0, y1, xd0, yd1),
			MathHelper.Gradient(this.configuration.Seed, x1, y1, xd1, yd1),
			xs);

		float result = MathHelper.LinearInterpolate(xf0, xf1, ys) * 1.4247691104677813f;

		return result;
	}

	private void Scale(ref float x, ref float y)
	{
		x *= this.configuration.Frequency;
		y *= this.configuration.Frequency;
	}
}
