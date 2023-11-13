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

			bool topBlockIsEmpty = blocks.ContainsKey(new Vector3(position.X, position.Y + 1, position.Z));

			if (!topBlockIsEmpty)
			{
				yield return new BlockFace(position.ToTopFace());
			}
		}
	}
}
