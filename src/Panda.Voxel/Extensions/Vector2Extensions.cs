using Microsoft.Xna.Framework;

namespace Panda.Voxel.Extensions;

public static class Vector2Extensions
{
	public static Vector3 ToVector3(this Vector2 vector, float y = default)
	{
		var result = new Vector3(vector.X, y, vector.Y);

		return result;
	}

	public static System.Numerics.Vector2 ToVector2(this Vector2 vector)
	{
		var result = new System.Numerics.Vector2(vector.X, vector.Y);

		return result;
	}
}
