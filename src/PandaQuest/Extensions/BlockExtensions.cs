using Microsoft.Xna.Framework;
using PandaQuest.Models;
using System.Net.WebSockets;

namespace PandaQuest.Extensions;

public static class BlockExtensions
{
	public static IEnumerable<BlockFace> ToMesh(this IDictionary<Vector3, Block> blocks)
	{
		foreach (KeyValuePair<Vector3, Block> keyValue in blocks)
		{
			Vector3 position = keyValue.Key;

			bool frontBlockIsEmpty = !blocks.ContainsKey(new Vector3(position.X, position.Y, position.Z - 1));
			bool backBlockIsEmplty = !blocks.ContainsKey(new Vector3(position.X, position.Y, position.Z + 1));

			bool rightFaceIsEmpty = !blocks.ContainsKey(new Vector3(position.X - 1, position.Y, position.Z));
			bool leftFaceIsEmpty = !blocks.ContainsKey(new Vector3(position.X + 1, position.Y, position.Z));

			bool topBlockIsEmpty = !blocks.ContainsKey(new Vector3(position.X, position.Y + 1, position.Z));
			bool bottomBlockIsEmpty = !blocks.ContainsKey(new Vector3(position.X, position.Y - 1, position.Z));

			if (frontBlockIsEmpty)
			{
				yield return new BlockFace(position.ToFrontFace());
			}
			if (backBlockIsEmplty)
			{
				yield return new BlockFace(position.ToBackFace());
			}

			if (rightFaceIsEmpty)
			{
				yield return new BlockFace(position.ToRightFace());
			}
			if (leftFaceIsEmpty)
			{
				yield return new BlockFace(position.ToLeftFace());
			}

			if (topBlockIsEmpty)
			{
				yield return new BlockFace(position.ToTopFace());
			}
			if (bottomBlockIsEmpty)
			{
				yield return new BlockFace(position.ToBottomFace());
			}
		}
	}
}
