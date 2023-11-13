using Microsoft.Xna.Framework;

namespace PandaQuest.Extensions;

public static class Vector2Extensions
{
	public static Vector3 ToVector3(this Vector2 vector, float y = default)
	{
		var result = new Vector3(vector.X, y, vector.Y);

		return result;
	}
}
