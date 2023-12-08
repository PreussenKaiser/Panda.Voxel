using Microsoft.Xna.Framework;

namespace Panda.Voxel.Configuration;

public sealed class FiniteWorldConfiguration(Vector2 dimensions)
{
	/// <summary>
	/// Length and width od the generated map.
	/// </summary>
	public readonly Vector2 Dimensions = dimensions;
}
