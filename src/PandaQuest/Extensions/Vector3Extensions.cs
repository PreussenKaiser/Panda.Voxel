using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PandaQuest.Configuration;

namespace PandaQuest.Extensions;

public static class Vector3Extensions
{
	public static VertexPositionTexture[] ToFrontFace(this Vector3 position)
	{
		var faces = new VertexPositionTexture[6]
		{
			new(position, new Vector2(0, 0)),
			new(new Vector3(position.X + 1, position.Y, position.Z), new Vector2(1, 0)),
			new(new Vector3(position.X, position.Y + 1, position.Z), new Vector2(0, 1)),

			new(new Vector3(position.X + 1, position.Y, position.Z), new Vector2(1, 0)),
			new(new Vector3(position.X + 1, position.Y + 1, position.Z), new Vector2(1, 1)),
			new(new Vector3(position.X, position.Y + 1, position.Z), new Vector2(0, 1)),
		};

		return faces;
	}

	public static VertexPositionTexture[] ToBackFace(this Vector3 position)
	{
		var faces = new VertexPositionTexture[6]
		{
			new(new Vector3(position.X, position.Y + 1, position.Z + 1), new Vector2(0, 1)),
			new(new Vector3(position.X + 1, position.Y, position.Z + 1), new Vector2(1, 0)),
			new(new Vector3(position.X, position.Y, position.Z + 1), new Vector2(0, 0)),

			new(new Vector3(position.X, position.Y + 1, position.Z + 1), new Vector2(0, 1)),
			new(new Vector3(position.X + 1, position.Y + 1, position.Z + 1), new Vector2(1, 1)),
			new(new Vector3(position.X + 1, position.Y, position.Z + 1), new Vector2(1, 0)),
		};

		return faces;
	}

	public static VertexPositionTexture[] ToLeftFace(this Vector3 position)
	{
		var faces = new VertexPositionTexture[6]
		{
			new(new Vector3(position.X + 1, position.Y, position.Z), new Vector2(0, 0)),
			new(new Vector3(position.X + 1, position.Y, position.Z + 1), new Vector2(1, 0)),
			new(new Vector3(position.X + 1, position.Y + 1, position.Z), new Vector2(0, 1)),

			new(new Vector3(position.X + 1, position.Y, position.Z + 1), new Vector2(1, 0)),
			new(new Vector3(position.X + 1, position.Y + 1, position.Z + 1), new Vector2(1, 1)),
			new(new Vector3(position.X + 1, position.Y + 1, position.Z), new Vector2(0, 1)),
		};

		return faces;
	}

	public static VertexPositionTexture[] ToRightFace(this Vector3 position)
	{
		var faces = new VertexPositionTexture[6]
		{
			new(new Vector3(position.X, position.Y + 1, position.Z + 1), new Vector2(0, 0)),
			new(new Vector3(position.X, position.Y, position.Z + 1), new Vector2(1, 0)),
			new(new Vector3(position.X, position.Y + 1, position.Z), new Vector2(0, 1)),

			new(new Vector3(position.X, position.Y, position.Z + 1), new Vector2(1, 0)),
			new(new Vector3(position.X, position.Y, position.Z), new Vector2(1, 1)),
			new(new Vector3(position.X, position.Y + 1, position.Z), new Vector2(0, 1)),
		};

		return faces;
	}
	
	public static VertexPositionTexture[] ToTopFace(this Vector3 position)
	{
		var faces = new VertexPositionTexture[6]
		{
			new(new Vector3(position.X + 1, position.Y + 1, position.Z + 1), new Vector2(1, 1)),
			new(new Vector3(position.X, position.Y + 1, position.Z + 1), new Vector2(0, 1)),
			new(new Vector3(position.X + 1, position.Y + 1, position.Z), new Vector2(1, 0)),

			new(new Vector3(position.X, position.Y + 1, position.Z + 1), new Vector2(0, 1)),
			new(new Vector3(position.X, position.Y + 1, position.Z), new Vector2(0, 0)),
			new(new Vector3(position.X + 1, position.Y + 1, position.Z), new Vector2(1, 0)),
		};

		return faces;
	}

	public static VertexPositionTexture[] ToBottomFace(this Vector3 position)
	{
		var faces = new VertexPositionTexture[6]
		{
			new(new Vector3(position.X, position.Y, position.Z + 1), new Vector2(0, 1)),
			new(new Vector3(position.X + 1, position.Y, position.Z + 1), new Vector2(1, 1)),
			new(new Vector3(position.X + 1, position.Y, position.Z), new Vector2(1, 0)),

			new(new Vector3(position.X + 1, position.Y, position.Z), new Vector2(1, 0)),
			new(new Vector3(position.X, position.Y, position.Z), new Vector2(0, 0)),
			new(new Vector3(position.X, position.Y, position.Z + 1), new Vector2(0, 1)),
		};

		return faces;
	}

	public static bool IsDescending(this Vector3 vector)
	{
		return vector.Y < 0;
	}

	public static Vector2 ToLocalPosition(this Vector3 position, WorldConfiguration configuration)
	{
		var result = new Vector2(
			position.X / configuration.ChunkSize,
			position.Z / configuration.ChunkSize);

		result.Round();

		return result;
	}

	public static Vector2 ToGlobalPosition(this Vector3 localPosition, Vector2 chunkPosition, WorldConfiguration configuration)
	{
		var result = new Vector2(
			chunkPosition.X * configuration.ChunkSize + localPosition.X,
			chunkPosition.Y * configuration.ChunkSize + localPosition.Z);

		result.Round();

		return result;
	}
}
