using System.Numerics;

namespace Panda.Noise.Abstractions;

/// <summary>
/// Implements 2 dimensional noise.
/// </summary>
public interface INoise2
{
	/// <returns>A value between -1 and 1.</returns>
	float GetValue(float x, float y);
}
